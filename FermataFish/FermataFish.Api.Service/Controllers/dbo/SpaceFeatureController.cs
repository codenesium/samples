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
	[Route("api/spaceFeatures")]
	[ApiVersion("1.0")]
	[Response]
	public class SpaceFeatureController: AbstractSpaceFeatureController
	{
		public SpaceFeatureController(
			ServiceSettings settings,
			ILogger<SpaceFeatureController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpaceFeature spaceFeatureManager
			)
			: base(settings,
			       logger,
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
    <Hash>f934930aefe83ba27372dd8f77a0d199</Hash>
</Codenesium>*/