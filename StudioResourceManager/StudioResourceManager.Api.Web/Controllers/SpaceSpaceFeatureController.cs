using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Web
{
	[Route("api/spaceSpaceFeatures")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]
	public class SpaceSpaceFeatureController : AbstractSpaceSpaceFeatureController
	{
		public SpaceSpaceFeatureController(
			ApiSettings settings,
			ILogger<SpaceSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceSpaceFeatureService spaceSpaceFeatureService,
			IApiSpaceSpaceFeatureModelMapper spaceSpaceFeatureModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceSpaceFeatureService,
			       spaceSpaceFeatureModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>dfc64bb94e28407247f0f235d323e537</Hash>
</Codenesium>*/