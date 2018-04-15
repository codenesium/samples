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
    <Hash>34b038a96d75d79ba0a6cac402b40860</Hash>
</Codenesium>*/