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
	[ResponseFilter]
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
    <Hash>7d595a3d396d5f19b644ce9ac0267f11</Hash>
</Codenesium>*/