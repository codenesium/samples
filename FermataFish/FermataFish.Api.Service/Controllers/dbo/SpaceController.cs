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
	[Route("api/spaces")]
	[ApiVersion("1.0")]
	[Response]
	public class SpaceController: AbstractSpaceController
	{
		public SpaceController(
			ServiceSettings settings,
			ILogger<SpaceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSpace spaceManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       spaceManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>368d6c7cc6f9dea7772e4578b117390d</Hash>
</Codenesium>*/