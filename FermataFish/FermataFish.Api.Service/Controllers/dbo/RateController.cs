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
	[Route("api/rates")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(RateFilter))]
	public class RateController: AbstractRateController
	{
		public RateController(
			ILogger<RateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRateRepository rateRepository
			)
			: base(logger,
			       transactionCoordinator,
			       rateRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>caccb7925da4a1abdd3c527cee4a402f</Hash>
</Codenesium>*/