using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StackOverflowNS.Api.Contracts;
using StackOverflowNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StackOverflowNS.Api.Web
{
	[Route("api/badges")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class BadgesController : AbstractBadgesController
	{
		public BadgesController(
			ApiSettings settings,
			ILogger<BadgesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBadgesService badgesService,
			IApiBadgesModelMapper badgesModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       badgesService,
			       badgesModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5a697fb129de08e32ee1d3754191d200</Hash>
</Codenesium>*/