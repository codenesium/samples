using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/spaceFeatures")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SpaceFeatureFilter))]
	public class SpaceFeatureController: AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceFeatureRepository spaceFeatureRepository
			)
			: base(logger,
			       transactionCoordinator,
			       spaceFeatureRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4b55e0518b1aa5c69f03bcfed98897b4</Hash>
</Codenesium>*/