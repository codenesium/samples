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
using FermataFishNS.Api.BusinessObjects;

namespace FermataFishNS.Api.Service
{
	[Route("api/spaceXSpaceFeatures")]
	[ApiVersion("1.0")]
	[Response]
	public class SpaceXSpaceFeatureController: AbstractSpaceXSpaceFeatureController
	{
		public SpaceXSpaceFeatureController(
			ServiceSettings settings,
			ILogger<SpaceXSpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceXSpaceFeature spaceXSpaceFeatureManager
			)
			: base(settings,
			       logger,
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
    <Hash>8df8865a29189d4e84e96a3eb6501f74</Hash>
</Codenesium>*/