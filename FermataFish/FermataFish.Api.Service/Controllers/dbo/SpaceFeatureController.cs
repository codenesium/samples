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
	[Route("api/spaceFeatures")]
	[ApiVersion("1.0")]
	public class SpaceFeatureController: AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceFeature spaceFeatureManager
			)
			: base(logger,
			       transactionCoordinator,
			       spaceFeatureManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>60154ac05550ad985d17e0a7efc5d943</Hash>
</Codenesium>*/