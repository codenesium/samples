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
			IApiMessengerServerModelMapper messengerModelMapper
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
    <Hash>f1229b0f7681d44663b31e36ef08b1f8</Hash>
</Codenesium>*/