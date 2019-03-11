using ESPIOTNS.Api.Contracts;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
	public interface IAuthService
	{
		Task<AuthResponse> Login(LoginRequestModel model);

		Task<AuthResponse> ConfirmEmail(ConfirmEmailRequestModel model);


		Task<AuthResponse> Register(RegisterRequestModel model);

		Task<AuthResponse> ResetPassword(ResetPasswordRequestModel model);
	}
}