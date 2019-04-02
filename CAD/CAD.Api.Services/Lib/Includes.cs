using CADNS.Api.Contracts;
using CADNS.Api.DataAccess;
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

namespace CADNS.Api.Services
{
	public abstract class AbstractService
	{
	}

	public abstract class AbstractBusinessObject
	{
	}

	public interface IEmailService
	{
		Task SendEmailAsync(string email, string subject, string message);
	}

	public class EmailService : IEmailService
	{
		private readonly ApiSettings apiSettings;

		public EmailService(ApiSettings apiSettings)
		{
			this.apiSettings = apiSettings;
		}

		public Task SendEmailAsync(string email, string subject, string message)
		{
			/* See https://docs.microsoft.com/en-us/aspnet/core/security/authentication/accconfirm for
			   // an example on how to send an email. There is also Amazon SES and any number of other
			   // providers. You can add any variables you need to the ApiSettings class and to the
			   // AppSettings.json files and you can access any credentials you may need.*/

			throw new Exception("You must provide an implementation to send emails");
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

		public static AuthResponse SuccessAuthResponse(string message = null)
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

	public interface IGuidService
	{
		Guid NewGuid();
	}

	public class GuidService : IGuidService
	{
		public Guid NewGuid()
		{
			return Guid.NewGuid();
		}
	}

	public partial class AuthService : IAuthService
	{
		private readonly ApiSettings apiSettings;

		private readonly UserManager<AuthUser> userManager;

		private readonly IEmailService emailService;

		private readonly IJwtService jwtService;

		private readonly IGuidService guidService;

		public AuthService(ApiSettings apiSettings, UserManager<AuthUser> userManager, IEmailService emailSService, IJwtService jwtService, IGuidService guidService)
		{
			this.apiSettings = apiSettings;
			this.userManager = userManager;
			this.emailService = emailSService;
			this.jwtService = jwtService;
			this.guidService = guidService;
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

					string token = this.jwtService.GenerateBearerToken(
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
					UserName = model.Email,
					Id = this.guidService.NewGuid().ToString()
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

						await this.emailService.SendEmailAsync(model.Email, "Registration", email);

						if (this.apiSettings.DebugSendAuthEmailsToClient)
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithLink(command, confirmationLink);
						}
						else
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse("Click the link sent to the provided email to complete registration");
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
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User already exists", AuthErrorCodes.UserAlreadyExists);
			}
		}

		public async Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				string confirmationToken = await this.userManager.GeneratePasswordResetTokenAsync(user);

				string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/confirmpasswordreset/{user.Id}/{UrlEncoder.Default.Encode(confirmationToken)}";

				string command = "Click this link to reset your password";

				if (this.apiSettings.DebugSendAuthEmailsToClient)
				{
					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithLink(command, confirmationLink);
				}
				else
				{
					string email = this.FormatLink(command, confirmationLink);

					await this.emailService.SendEmailAsync(model.Email, "Password Reset", email);

					return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse("Click the link sent to the provided email to reset your password");
				}
			}
		}

		public async Task<AuthResponse> ChangeEmail(ChangeEmailRequestModel model, string currentEmail)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(currentEmail);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				if (this.userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
				{
					user.NewEmail = model.NewEmail;

					IdentityResult updateResult = await this.userManager.UpdateAsync(user);

					if (updateResult.Succeeded)
					{
						string confirmationToken = await this.userManager.GenerateChangeEmailTokenAsync(user, model.NewEmail);

						string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/confirmchangeemail/{user.Id}/{UrlEncoder.Default.Encode(confirmationToken)}";

						string command = "Click the link to change your email";

						string email = this.FormatLink(command, confirmationLink);

						await this.emailService.SendEmailAsync(model.NewEmail, "Change Email", email);

						if (this.apiSettings.DebugSendAuthEmailsToClient)
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponseWithLink(command, confirmationLink);
						}
						else
						{
							return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse("Click the link sent to the provided email to complete changing your account email");
						}
					}
					else
					{
						return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("Unable to update user", AuthErrorCodes.UnableToUpdateUser);
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
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
			}
			else
			{
				IdentityResult result = await this.userManager.ChangeEmailAsync(user, user.NewEmail, System.Net.WebUtility.UrlDecode(model.Token));

				if (result.Succeeded)
				{
					user.NewEmail = string.Empty;

					var updateResult = await this.userManager.UpdateAsync(user);

					if (updateResult.Succeeded)
					{
						return ValidationResponseFactory<AuthResponse>.SuccessAuthResponse();
					}
					else
					{
						return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(updateResult, AuthErrorCodes.UnableToUpdateUser);
					}
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.FailureAuthResponse(result, AuthErrorCodes.UnableToChangeEmail);
				}
			}
		}

		public async Task<AuthResponse> ChangePassword(ChangePasswordRequestModel model, string email)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
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
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
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
				return ValidationResponseFactory<AuthResponse>.FailureAuthResponse("User not found", AuthErrorCodes.UserDoesNotExist);
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

	public interface IJwtService
	{
		string GenerateBearerToken(string signingKey, string audience, string issuer, string userId, string email, IList<Claim> claims);
	}

	public class JwtService : IJwtService
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
    <Hash>f5f189fdc4d5f3ce6c24b9bb32105638</Hash>
</Codenesium>*/