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
	[Route("api/spaceSpaceFeatures")]
	[ApiController]
	[ApiVersion("1.0")]

	public class SpaceSpaceFeatureController : AbstractSpaceSpaceFeatureController
	{
		public SpaceSpaceFeatureController(
			ApiSettings settings,
			ILogger<SpaceSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceSpaceFeatureService spaceSpaceFeatureService,
			IApiSpaceSpaceFeatureServerModelMapper spaceSpaceFeatureModelMapper
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
    <Hash>8854ec4b3cdb25498de7eedd8924a1f2</Hash>
</Codenesium>*/