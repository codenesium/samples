using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/spaceXSpaceFeatures")]
	[ApiVersion("1.0")]
	public class SpaceXSpaceFeatureController: AbstractSpaceXSpaceFeatureController
	{
		public SpaceXSpaceFeatureController(
			ILogger<SpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceXSpaceFeature spaceXSpaceFeatureManager
			)
			: base(logger,
			       transactionCoordinator,
			       spaceXSpaceFeatureManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d095331cd884e7d84ad0e98982f947c9</Hash>
</Codenesium>*/