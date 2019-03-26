using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.DataAccess;

namespace TicketingCRMNS.Api.Services
{
	public abstract class AbstractService
	{
	}

	public abstract class AbstractBusinessObject
	{
	}

	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
	}

	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string email, string subject, string message)
		{
			return Task.CompletedTask;
		}
	}

	public class ApiSettings
	{
		public virtual string DatabaseProvider { get; set; }

		public virtual string ExternalBaseUrl { get; set; }

		public virtual bool MigrateDatabase { get; set; }

		public virtual bool DebugSendAuthEmailsToClient { get; set; }

		public virtual string JwtSigningKey { get; set; }

		public virtual string JwtIssuer { get; set; }

		public virtual string JwtAudience { get; set; }
	}

	public static class ValidationResponseFactory<T>
	{
		public static CreateResponse<T> CreateResponse(T record)
		{
			return new CreateResponse<T>(record);
		}

		public static CreateResponse<T> CreateResponse(ValidationResult result)
		{
			var response = new CreateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static UpdateResponse<T> UpdateResponse(T record)
		{
			return new UpdateResponse<T>(record);
		}

		public static UpdateResponse<T> UpdateResponse(ValidationResult result)
		{
			var response = new UpdateResponse<T>();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static ActionResponse ActionResponse(ValidationResult result)
		{
			var response = new ActionResponse();
			response.Success = result.IsValid;
			foreach (ValidationFailure error in result.Errors)
			{
				response.ValidationErrors.Add(new ValidationError(error.ErrorCode, error.ErrorMessage, error.PropertyName));
			}

			return response;
		}

		public static AuthResponse SuccessAuthResponse(string message = "")
		{
			var response = new AuthResponse();
			response.SetMessage(message);
			response.Success = true;
			return response;
		}

		public static AuthResponse SuccessAuthResponseWithToken(string token)
		{
			var response = new AuthResponse();
			response.Success = true;
			response.SetToken(token);
			return response;
		}

		public static AuthResponse SuccessAuthResponseWithLink(string linkText, string linkValue)
		{
			var response = new AuthResponse();
			response.Success = true;
			response.SetLink(linkText, linkValue);
			return response;
		}

		public static AuthResponse FailureAuthResponse(string message, string errorCode)
		{
			var response = new AuthResponse();
			response.Success = false;
			response.SetMessage(message);
			response.SetErrorCode(errorCode);
			return response;
		}

		public static AuthResponse FailureAuthResponse(IdentityResult identityResult, string errorCode)
		{
			var response = new AuthResponse();
			response.Success = false;

			string message = string.Empty;
			foreach (var error in identityResult.Errors)
			{
				message += error.Description + Environment.NewLine;
			}

			response.SetMessage(message);
			response.SetErrorCode(errorCode);

			return response;
		}
	}

	public partial class AuthService : IAuthService
	{
		private readonly ApiSettings apiSettings;

		private readonly UserManager<AuthUser> userManager;

		private readonly IEmailSender emailSender;

		private readonly IJWTHelper jwtHelper;

		public AuthService(ApiSettings apiSettings, UserManager<AuthUser> userManager, IEmailSender emailSender, IJWTHelper jwtHelper)
		{
			this.apiSettings = apiSettings;
			this.userManager = userManager;
			this.emailSender = emailSender;
			this.jwtHelper = jwtHelper;
		}

		public async Task<AuthResponse> Login(LoginRequestModel model)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("Invalid email or password", AuthErrorCodes.InvalidUsernameOrPassword);
			}
			else
			{
				if (this.userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
				{
					string token = this.jwtHelper.GenerateBearerToken(
						this.apiSettings.JwtSigningKey,
						this.apiSettings.JwtAudience,
						this.apiSettings.JwtIssuer,
						user.Id,
						user.Email);

					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithToken(token);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("Invalid email or password", AuthErrorCodes.InvalidUsernameOrPassword);
				}
			}
		}

		public async Task<AuthResponse> Register(RegisterRequestModel model)
		{
			IdentityUser existingUser = await this.userManager.FindByEmailAsync(model.Email);

			if (existingUser == null)
			{
				AuthUser user = new AuthUser
				{
					Email = model.Email,
					UserName = model.Email
				};

				IdentityResult result = await this.userManager.CreateAsync(user);

				if (result.Succeeded)
				{
					IdentityResult addPasswordResult = await this.userManager.AddPasswordAsync(user, model.Password);

					if (addPasswordResult.Succeeded)
					{
						string confirmationToken = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

						string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/confirmregistration/{user.Id}/{UrlEncoder.Default.Encode(confirmationToken)}";

						string command = "Click the link to complete registration.";

						string email = this.FormatLink(command, confirmationLink);

						await this.emailSender.SendEmailAsync(model.Email, "Registration", email);

						if (this.apiSettings.DebugSendAuthEmailsToClient)
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithLink(command, confirmationLink);
						}
						else
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
						}
					}
					else
					{
						return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(addPasswordResult, AuthErrorCodes.UnableToRegister);
					}
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(result, AuthErrorCodes.UnableToRegister);
				}
			}
			else
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Already Exists", AuthErrorCodes.UserAlreadyExists);
			}
		}

		public async Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				string confirmationToken = await this.userManager.GeneratePasswordResetTokenAsync(user);

				string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/confirmpasswordreset/{user.Id}/{UrlEncoder.Default.Encode(confirmationToken)}";

				string command = "Click the link to reset your password.";

				string email = this.FormatLink(command, confirmationLink);

				await this.emailSender.SendEmailAsync(model.Email, "Password Reset", email);

				if (this.apiSettings.DebugSendAuthEmailsToClient)
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithLink(command, confirmationLink);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
				}
			}
		}

		public async Task<AuthResponse> ChangePassword(ChangePasswordRequestModel model, string email)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				IdentityResult result = await this.userManager.ChangePasswordAsync(user, model.CurrentPassword, model.NewPassword);

				if (result.Succeeded)
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(result, AuthErrorCodes.UnableToChangePassword);
				}
			}
		}

		public async Task<AuthResponse> ConfirmRegistration(ConfirmRegistrationRequestModel model)
		{
			AuthUser user = await this.userManager.FindByIdAsync(model.Id);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				IdentityResult result = await this.userManager.ConfirmEmailAsync(user, System.Net.WebUtility.UrlDecode(model.Token));

				if (result.Succeeded)
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(result, AuthErrorCodes.UnableToConfirmRegistration);
				}
			}
		}

		public async Task<AuthResponse> ConfirmPasswordReset(ConfirmPasswordResetRequestModel model)
		{
			AuthUser user = await this.userManager.FindByIdAsync(model.Id);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				IdentityResult result = await this.userManager.ResetPasswordAsync(user, System.Net.WebUtility.UrlDecode(model.Token), model.NewPassword);

				if (result.Succeeded)
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(result, AuthErrorCodes.UnableToConfirmPasssordReset);
				}
			}
		}

		private string FormatLink(string message, string link)
		{
			return $@"{message} <a href=""{link}"">{link}</a>";
		}
	}

	public interface IJWTHelper
	{
		string GenerateBearerToken(string signingKey, string audience, string issuer, string id, string email);
	}

	public class JWTHelper : IJWTHelper
	{
		public string GenerateBearerToken(string signingKey, string audience, string issuer, string id, string email)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.UTF8.GetBytes(signingKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, id),
					new Claim(ClaimTypes.Email, email)
				}),
				Audience = audience,
				Issuer = issuer,
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}

	public class ConfirmPasswordResetRequestModel
	{
		public string Id { get; set; }

		public string Token { get; set; }

		public string NewPassword { get; set; }
	}

	public class ConfirmRegistrationRequestModel
	{
		public string Id { get; set; }

		public string Token { get; set; }
	}

	public interface IAuthService
	{
		Task<AuthResponse> ChangePassword(ChangePasswordRequestModel model, string email);

		Task<AuthResponse> ConfirmRegistration(ConfirmRegistrationRequestModel model);

		Task<AuthResponse> ConfirmPasswordReset(ConfirmPasswordResetRequestModel model);

		Task<AuthResponse> Login(LoginRequestModel model);

		Task<AuthResponse> Register(RegisterRequestModel model);

		Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model);
	}

	public class LoginRequestModel
	{
		public string Email { get; set; }

		public string Password { get; set; }

		public void SetProperties(string email, string password)
		{
			this.Email = email;
			this.Password = password;
		}
	}

	public class RegisterRequestModel
	{
		public string Email { get; set; }

		public string Password { get; set; }
	}

	public class ResetPasswordRequestModel
	{
		public string Email { get; set; }
	}

	public class ChangePasswordRequestModel
	{
		public string CurrentPassword { get; set; }

		public string NewPassword { get; set; }
	}
}

/*<Codenesium>
    <Hash>aa0877d7ea2dfa84ae9ee045ee040d07</Hash>
</Codenesium>*/