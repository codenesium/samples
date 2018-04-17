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
	[Route("api/states")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class StateController: AbstractStateController
	{
		public StateController(
			ILogger<StateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOState stateManager
			)
			: base(logger,
			       transactionCoordinator,
			       stateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ce60b4da71537b731d9bc55f4971feb0</Hash>
</Codenesium>*/