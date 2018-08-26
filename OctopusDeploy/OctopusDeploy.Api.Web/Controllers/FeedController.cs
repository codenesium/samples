using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OctopusDeployNS.Api.Web
{
	[Route("api/feeds")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class FeedController : AbstractFeedController
	{
		public FeedController(
			ApiSettings settings,
			ILogger<FeedController> logger,
			ITransactionCoordinator transactionCoordinator,
			IFeedService feedService,
			IApiFeedModelMapper feedModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       feedService,
			       feedModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a78d8522269e23f2067f0542ed762ed3</Hash>
</Codenesium>*/