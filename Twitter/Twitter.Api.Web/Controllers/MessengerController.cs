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
	[Route("api/messengers")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class MessengerController : AbstractMessengerController
	{
		public MessengerController(
			ApiSettings settings,
			ILogger<MessengerController> logger,
			ITransactionCoordinator transactionCoordinator,
			IMessengerService messengerService,
			IApiMessengerModelMapper messengerModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       messengerService,
			       messengerModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e602827412e05aa4394352e094a29534</Hash>
</Codenesium>*/