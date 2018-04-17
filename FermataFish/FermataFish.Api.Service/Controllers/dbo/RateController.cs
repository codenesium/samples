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
	[Route("api/rates")]
	[ApiVersion("1.0")]
	public class RateController: AbstractRateController
	{
		public RateController(
			ILogger<RateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBORate rateManager
			)
			: base(logger,
			       transactionCoordinator,
			       rateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8dc91d233bfb4b670b23a523380308ed</Hash>
</Codenesium>*/