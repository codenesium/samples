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
	[Route("api/replies")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class ReplyController : AbstractReplyController
	{
		public ReplyController(
			ApiSettings settings,
			ILogger<ReplyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IReplyService replyService,
			IApiReplyServerModelMapper replyModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       replyService,
			       replyModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>338a56f00e14e6e8ad5eb9b46e53750a</Hash>
</Codenesium>*/