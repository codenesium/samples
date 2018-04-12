using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Service
{
	[Route("api/spaceXSpaceFeatures")]
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
    <Hash>3d648afef859518edc6c1459083ba1a9</Hash>
</Codenesium>*/