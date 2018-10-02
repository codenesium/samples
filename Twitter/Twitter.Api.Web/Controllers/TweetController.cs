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
	[Route("api/tweets")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class TweetController : AbstractTweetController
	{
		public TweetController(
			ApiSettings settings,
			ILogger<TweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			ITweetService tweetService,
			IApiTweetModelMapper tweetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       tweetService,
			       tweetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7cbb33eebb5f376fb440dc8dbc20e9fb</Hash>
</Codenesium>*/