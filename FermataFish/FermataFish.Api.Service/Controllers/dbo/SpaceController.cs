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
	[Route("api/spaces")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(SpaceFilter))]
	public class SpaceController: AbstractSpaceController
	{
		public SpaceController(
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceRepository spaceRepository
			)
			: base(logger,
			       transactionCoordinator,
			       spaceRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d514d52e3787dec0100fa5c2a43df244</Hash>
</Codenesium>*/