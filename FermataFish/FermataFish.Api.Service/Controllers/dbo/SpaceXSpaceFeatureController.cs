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
	[Route("api/spaceXSpaceFeatures")]
	[ApiVersion("1.0")]
	public class SpaceXSpaceFeatureController: AbstractSpaceXSpaceFeatureController
	{
		public SpaceXSpaceFeatureController(
			ILogger<SpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceXSpaceFeatureRepository spaceXSpaceFeatureRepository,
			ISpaceXSpaceFeatureModelValidator spaceXSpaceFeatureModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       spaceXSpaceFeatureRepository,
			       spaceXSpaceFeatureModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f875a3d91ff6be0bc1757b6c43322ee9</Hash>
</Codenesium>*/