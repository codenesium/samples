using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Auth
{
	public interface IAuthService
	{
		Task<AuthenticateResponseModel> Authenticate(AuthenticateRequestModel model);
		Task<RegisterResponseModel> Register(RegisterRequestModel model);
		Task<ResetPasswordResponseModel> ResetPassword(ResetPasswordRequestModel model);
	}
}