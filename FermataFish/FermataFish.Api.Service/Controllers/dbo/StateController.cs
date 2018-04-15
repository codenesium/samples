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
	[Route("api/states")]
	[ApiVersion("1.0")]
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
    <Hash>080fb74b564ae792a2131830d84ae454</Hash>
</Codenesium>*/