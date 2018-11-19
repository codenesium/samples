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

	public class RetweetController : AbstractRetweetController
	{
		public RetweetController(
			ApiSettings settings,
			ILogger<RetweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRetweetService retweetService,
			IApiRetweetServerModelMapper retweetModelMapper
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
    <Hash>8a8b0639b48932f01d8e647855378fbf</Hash>
</Codenesium>*/