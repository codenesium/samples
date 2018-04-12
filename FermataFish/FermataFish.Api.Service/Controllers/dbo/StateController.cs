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
	[Route("api/states")]
	public class StateController: AbstractStateController
	{
		public StateController(
			ILogger<StateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateRepository stateRepository,
			IStateModelValidator stateModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       stateRepository,
			       stateModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>de905aacb5ef387700bec4bd8de4bce7</Hash>
</Codenesium>*/