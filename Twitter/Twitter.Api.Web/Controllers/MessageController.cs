using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TwitterNS.Api.Contracts;
using TwitterNS.Api.Services;

namespace TwitterNS.Api.Web
{
	[Route("api/messages")]
	[ApiController]
	[ApiVersion("1.0")]

	public class MessageController : AbstractMessageController
	{
		public MessageController(
			ApiSettings settings,
			ILogger<MessageController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMessageService messageService,
			IApiMessageServerModelMapper messageModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       messageService,
			       messageModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ef1673db2b2ec073769491f48f6ad6cf</Hash>
</Codenesium>*/