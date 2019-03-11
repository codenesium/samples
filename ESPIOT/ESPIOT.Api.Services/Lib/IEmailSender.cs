using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Lib
{
	public interface IEmailSender
	{
		Task SendEmailAsync(string email, string subject, string message);
	}
}