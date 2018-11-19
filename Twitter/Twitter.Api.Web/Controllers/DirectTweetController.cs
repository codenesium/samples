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
	[Route("api/directTweets")]
	[ApiController]
	[ApiVersion("1.0")]

	public class DirectTweetController : AbstractDirectTweetController
	{
		public DirectTweetController(
			ApiSettings settings,
			ILogger<DirectTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IDirectTweetService directTweetService,
			IApiDirectTweetServerModelMapper directTweetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       directTweetService,
			       directTweetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2050802df04b8b8ca3e72050a301eda6</Hash>
</Codenesium>*/