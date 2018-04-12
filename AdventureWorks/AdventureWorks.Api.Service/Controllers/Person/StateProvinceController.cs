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
	public class StateProvinceController: AbstractStateProvinceController
	{
		public StateProvinceController(
			ILogger<StateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IStateProvinceRepository stateProvinceRepository,
			IStateProvinceModelValidator stateProvinceModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       stateProvinceRepository,
			       stateProvinceModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4c096a9bd4e26841e6a910b0bc41fe48</Hash>
</Codenesium>*/