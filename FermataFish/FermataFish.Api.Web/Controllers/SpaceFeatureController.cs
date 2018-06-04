using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
	[Route("api/spaceFeatures")]
	[ApiVersion("1.0")]
	public class SpaceFeatureController: AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ServiceSettings settings,
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceFeatureService spaceFeatureService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceFeatureService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>92575485013c26586a2d97994ac16f44</Hash>
</Codenesium>*/