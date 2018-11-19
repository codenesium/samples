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
	[Route("api/quoteTweets")]
	[ApiController]
	[ApiVersion("1.0")]

	public class QuoteTweetController : AbstractQuoteTweetController
	{
		public QuoteTweetController(
			ApiSettings settings,
			ILogger<QuoteTweetController> logger,
			ITransactionCoordinator transactionCoordinator,
			IQuoteTweetService quoteTweetService,
			IApiQuoteTweetServerModelMapper quoteTweetModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       quoteTweetService,
			       quoteTweetModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5731862c519871d4f3863604b5dc7f95</Hash>
</Codenesium>*/