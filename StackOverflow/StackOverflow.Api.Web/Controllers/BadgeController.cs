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

	public class BadgeController : AbstractBadgeController
	{
		public BadgeController(
			ApiSettings settings,
			ILogger<BadgeController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBadgeService badgeService,
			IApiBadgeServerModelMapper badgeModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       badgeService,
			       badgeModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ce7d369bb91ee07fabe1f766818c1419</Hash>
</Codenesium>*/