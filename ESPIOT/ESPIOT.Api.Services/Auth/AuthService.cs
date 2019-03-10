using ESPIOTNS.Api.Contracts;
using ESPIOTNS.Api.DataAccess;
using MediatR;
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
		private ApiSettings apiSettings;

		public AuthService(ApiSettings apiSettings)
		{
			this.apiSettings = apiSettings;
		}
		
		public async Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel model)
		{
			var tokenHandler = new JwtSecurityTokenHandler();
			byte [] key = Encoding.UTF8.GetBytes(this.apiSettings.JwtSettings.SigningKey);
			var tokenDescriptor = new SecurityTokenDescriptor
			{
				Subject = new ClaimsIdentity(new Claim[]
				{
					new Claim(ClaimTypes.Name, model.Email)
				}),
				Audience = this.apiSettings.JwtSettings.Audience,
				Issuer = this.apiSettings.JwtSettings.Issuer,
				Expires = DateTime.UtcNow.AddDays(7),
				SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
			};

			SecurityToken token = tokenHandler.CreateToken(tokenDescriptor);
			var response = new AuthenticateResponseModel();
			response.SetProperties(true, tokenHandler.WriteToken(token));

			return response;
		}

		public async Task<RegisterResponseModel> Register(RegisterRequestModel model)
		{
			await Task.Delay(1000);
			return new RegisterResponseModel();
		}

		public async Task<ResetPasswordResponseModel> ResetPassword(ResetPasswordRequestModel model)
		{
			await Task.Delay(1000);
			return new ResetPasswordResponseModel();
		}


	}
}
