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
			IApiTweetServerModelMapper tweetModelMapper
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
    <Hash>fc875290b5f861afbc055535b1283037</Hash>
</Codenesium>*/