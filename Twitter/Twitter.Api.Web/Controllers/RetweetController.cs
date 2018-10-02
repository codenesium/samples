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
	[Route("api/retweets")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class RetweetController : AbstractRetweetController
	{
		public RetweetController(
			ApiSettings settings,
			ILogger<RetweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRetweetService retweetService,
			IApiRetweetModelMapper retweetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       retweetService,
			       retweetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7f1efb55453a3a22a24db1ff3cf05ab9</Hash>
</Codenesium>*/