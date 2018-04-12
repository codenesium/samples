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
	[Route("api/spaces")]
	public class SpaceController: AbstractSpaceController
	{
		public SpaceController(
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISpaceRepository spaceRepository,
			ISpaceModelValidator spaceModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       spaceRepository,
			       spaceModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bd34e6170700803960a7f4a80a64f59c</Hash>
</Codenesium>*/