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
	[Route("api/releases")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class ReleaseController : AbstractReleaseController
	{
		public ReleaseController(
			ApiSettings settings,
			ILogger<ReleaseController> logger,
			ITransactionCoordinator transactionCoordinator,
			IReleaseService releaseService,
			IApiReleaseModelMapper releaseModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       releaseService,
			       releaseModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>636388e2d3f7efa398bac89e8f3f8ab4</Hash>
</Codenesium>*/