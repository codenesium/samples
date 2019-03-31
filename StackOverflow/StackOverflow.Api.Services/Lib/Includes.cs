using FluentValidation.Results;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Text.Encodings.Web;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Services
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

		public virtual JwtSettings JwtSettings { get; set; }

		public virtual StripeSettings StripeSettings { get; set; }
	}

	public class JwtSettings
	{
		public virtual string SigningKey { get; set; }

		public virtual string Issuer { get; set; }

		public virtual string Audience { get; set; }
	}

	public class StripeSettings
	{
		public virtual string SecretKey { get; set; }

		public virtual string PublishableKey { get; set; }
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

	public interface IAuthService
	{
		Task<AuthResponse> ChangeEmail(ChangeEmailRequestModel model, string currentEmail);

		Task<AuthResponse> ConfirmChangeEmail(ConfirmChangeEmailRequestModel model, string currentEmail);

		Task<AuthResponse> ChangePassword(ChangePasswordRequestModel model, string email);

		Task<AuthResponse> Login(LoginRequestModel model);

		Task<AuthResponse> Register(RegisterRequestModel model);

		Task<AuthResponse> ConfirmRegistration(ConfirmRegistrationRequestModel model);

		Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model);

		Task<AuthResponse> ConfirmPasswordReset(ConfirmPasswordResetRequestModel model);
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
					IList<Claim> claims = await this.userManager.GetClaimsAsync(user);

					IList<string> roles = await this.userManager.GetRolesAsync(user);

					foreach (string role in roles)
					{
						claims.Add(new Claim(ClaimTypes.Role, role));
					}

					string token = this.jwtHelper.GenerateBearerToken(
						this.apiSettings.JwtSettings.SigningKey,
						this.apiSettings.JwtSettings.Audience,
						this.apiSettings.JwtSettings.Issuer,
						user.Id,
						user.Email,
						claims);

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

						string command = "Click this link to complete registration";

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

				string command = "Click this link to reset your password";

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

		public async Task<AuthResponse> ChangeEmail(ChangeEmailRequestModel model, string currentEmail)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(currentEmail);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				if (this.userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
				{
					user.NewEmail = model.NewEmail;

					await this.userManager.UpdateAsync(user);

					string confirmationToken = await this.userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);

					string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/confirmchangeemail/{user.Id}/{UrlEncoder.Default.Encode(confirmationToken)}";

					string command = "Click the link to change your email";

					string email = this.FormatLink(command, confirmationLink);

					await this.emailSender.SendEmailAsync(model.NewEmail, "Change Email", email);

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
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("Invalid email or password", AuthErrorCodes.InvalidUsernameOrPassword);
				}
			}
		}

		public async Task<AuthResponse> ConfirmChangeEmail(ConfirmChangeEmailRequestModel model, string currentEmail)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(currentEmail);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User Not Found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				IdentityResult result = await this.userManager.ChangeEmailAsync(user, user.NewEmail, System.Net.WebUtility.UrlDecode(model.Token));

				user.NewEmail = string.Empty;

				await this.userManager.UpdateAsync(user);

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
		string GenerateBearerToken(string signingKey, string audience, string issuer, string userId, string email, IList<Claim> claims);
	}

	public class JWTHelper : IJWTHelper
	{
		public string GenerateBearerToken(string signingKey, string audience, string issuer, string userId, string email, IList<Claim> claims)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.UTF8.GetBytes(signingKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, userId),
					new Claim(ClaimTypes.Email, email)
				}),
				Audience = audience,
				Issuer = issuer,
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			foreach (Claim claim in claims)
			{
				tokenDescriptor.Subject.AddClaim(claim);
			}

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}

/*<Codenesium>
    <Hash>0bb65a5a13b87b4da1b8052f84e8bc83</Hash>
</Codenesium>*/