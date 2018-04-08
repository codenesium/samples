using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
namespace AdventureWorksNS.Api.Service
{
	[Route("api/stateProvinces")]
	public class StateProvincesController: AbstractStateProvincesController
	{
		public StateProvincesController(
			ILogger<StateProvincesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator
			) : base(logger,
			         transactionCoordinator,
			         stateProvinceRepository,
			         stateProvinceModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5aeeea32144ada1dbe7345f2fa7a15f4</Hash>
</Codenesium>*/