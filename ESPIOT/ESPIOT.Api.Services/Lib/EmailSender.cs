using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Lib
{
	public class EmailSender : IEmailSender
	{
		public Task SendEmailAsync(string subject, string message, string email)
		{
			return Task.CompletedTask;
		}
	}
}
