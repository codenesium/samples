using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace ESPIOTNS.Api.Services.Lib
{
	public class EmailSender : IEmailSender
	{
		//private readonly ILogger logger;

		//public EmailSender(ILogger logger)
		//{
		//	this.logger = logger;
		//}

		public Task SendEmailAsync(string email, string subject, string message)
		{
			//this.logger.LogDebug($"Sending email. Email={email}. Subject={subject}. Message={message}.");
			return Task.CompletedTask;
		}
	}
}
