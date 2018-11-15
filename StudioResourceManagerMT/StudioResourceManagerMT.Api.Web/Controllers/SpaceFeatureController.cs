using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Web
{
	[Route("api/spaceFeatures")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SpaceFeatureController : AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ApiSettings settings,
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceFeatureService spaceFeatureService,
			IApiSpaceFeatureServerModelMapper spaceFeatureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceFeatureService,
			       spaceFeatureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>aa0c639773721f9f6e951e1e52c0d202</Hash>
</Codenesium>*/