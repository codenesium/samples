using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/stateProvinces")]
	[ApiVersion("1.0")]
	[Response]
	public class StateProvinceController: AbstractStateProvinceController
	{
		public StateProvinceController(
			ServiceSettings settings,
			ILogger<StateProvinceController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOStateProvince stateProvinceManager
			)
			: base(settings,
			       logger,
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
    <Hash>afa87305d2431e8ac1e8e005fdf366e3</Hash>
</Codenesium>*/