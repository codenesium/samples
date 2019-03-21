using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using ESPIOTNS.Api.Services.Lib;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
	public partial class AuthService : IAuthService
	{
		private readonly ApiSettings apiSettings;

		private readonly UserManager<AuthUser> userManager;

		private readonly IEmailSender emailSender;

		public AuthService(ApiSettings apiSettings, UserManager<AuthUser> userManager, IEmailSender emailSender)
		{
			this.apiSettings = apiSettings;
			this.userManager = userManager;
			this.emailSender = emailSender;
		}
		
		public async Task<AuthResponse> Login(LoginRequestModel model)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{

				return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "User not found", "ERROR CODE", string.Empty, string.Empty);
			}
			else
			{
				if (this.userManager.PasswordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password) == PasswordVerificationResult.Success)
				{
					string token = this.GenerateBearerToken(
						this.apiSettings.JwtSettings.SigningKey,
						this.apiSettings.JwtSettings.Audience,
						this.apiSettings.JwtSettings.Issuer,
						user);

					return ValidationResponseFactory<AuthResponse>.AuthResponse(true, string.Empty, string.Empty, token, string.Empty);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "Invalid email or password", "ERROR CODE", string.Empty, string.Empty);
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

				user.PasswordHash = this.userManager.PasswordHasher.HashPassword(user, model.Password);

				IdentityResult result = await this.userManager.CreateAsync(user);

				if (result.Succeeded)
				{
					string confirmationToken = await this.userManager.GenerateEmailConfirmationTokenAsync(user);

					string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/auth/confirmregistration/{user.Id}/{System.Net.WebUtility.UrlEncode(confirmationToken)}";

					await this.emailSender.SendEmailAsync(model.Email, "Registration", $"Click the link to complete registration.  {confirmationLink}");
					
					return ValidationResponseFactory<AuthResponse>.AuthResponse(true, string.Empty, string.Empty, string.Empty, string.Empty);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "Error occured", "ERROR CODE", string.Empty, string.Empty);
				}

			}
			else
			{
				return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "User Already Exists", "ERROR CODE", string.Empty, string.Empty);
			}
		}

		public async Task<AuthResponse> ConfirmRegistration(ConfirmRegistrationRequestModel model)
		{

			AuthUser user = await this.userManager.FindByIdAsync(model.Id);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "User Not Found", "ERROR CODE", string.Empty, string.Empty);
			}
			else
			{
				IdentityResult result = await this.userManager.ConfirmEmailAsync(user, System.Net.WebUtility.UrlDecode(model.Token));

				if (result.Succeeded)
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(true, string.Empty, string.Empty, string.Empty, string.Empty);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(false, result, "ERROR CODE", string.Empty, string.Empty);
				}
			}
		}

		public async Task<AuthResponse> ConfirmPasswordReset(ConfirmPasswordResetRequestModel model)
		{

			AuthUser user = await this.userManager.FindByIdAsync(model.Id);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "User Not Found", "ERROR CODE", string.Empty, string.Empty);
			}
			else
			{
				IdentityResult result = await this.userManager.ResetPasswordAsync(user, System.Net.WebUtility.UrlDecode(model.Token), model.NewPassword);

				if (result.Succeeded)
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(true, string.Empty, string.Empty, string.Empty, string.Empty);
				}
				else
				{
					return ValidationResponseFactory<AuthResponse>.AuthResponse(false, result, "ERROR CODE", string.Empty, string.Empty);
				}
			}
		}

		public async Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model)
		{
			AuthUser user = await this.userManager.FindByEmailAsync(model.Email);

			if (user == null)
			{
				return ValidationResponseFactory<AuthResponse>.AuthResponse(false, "User Not Found", "ERROR CODE", string.Empty, string.Empty);
			}
			else
			{
				string confirmationToken = await this.userManager.GeneratePasswordResetTokenAsync(user);
				string confirmationLink = $"{this.apiSettings.ExternalBaseUrl}/auth/confirmpasswordreset/{user.Id}/{System.Net.WebUtility.UrlEncode(confirmationToken)}";

				await this.emailSender.SendEmailAsync(model.Email, "Password Reset", $"Click the link to reset your password.  {confirmationLink}");

				return ValidationResponseFactory<AuthResponse>.AuthResponse(true, string.Empty, string.Empty, string.Empty, string.Empty);
			}
		}

		private string GenerateBearerToken(string signingKey, string audience, string issuer, AuthUser user)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			byte[] key = Encoding.UTF8.GetBytes(signingKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, user.Id),
					new Claim(ClaimTypes.Email, user.Email)
				}),
				Audience = this.apiSettings.JwtSettings.Audience,
				Issuer = this.apiSettings.JwtSettings.Issuer,
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);

			return tokenHandler.WriteToken(token);
		}
	}
}
