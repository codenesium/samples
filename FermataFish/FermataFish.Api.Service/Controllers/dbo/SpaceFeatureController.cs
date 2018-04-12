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
	[Route("api/spaceFeatures")]
	public class SpaceFeatureController: AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceFeatureRepository spaceFeatureRepository,
			ISpaceFeatureModelValidator spaceFeatureModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       spaceFeatureRepository,
			       spaceFeatureModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ea8bbfadb208ea23a73b44100cde9586</Hash>
</Codenesium>*/