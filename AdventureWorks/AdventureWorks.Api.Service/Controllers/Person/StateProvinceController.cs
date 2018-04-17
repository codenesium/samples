using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/stateProvinces")]
	[ApiVersion("1.0")]
	public class StateProvinceController: AbstractStateProvinceController
	{
		public StateProvinceController(
			ILogger<StateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStateProvince stateProvinceManager
			)
			: base(logger,
			       transactionCoordinator,
			       stateProvinceManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>51f7224c1971764a40a76ba018b76ffb</Hash>
</Codenesium>*/