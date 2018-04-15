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
	public class RateController: AbstractRateController
	{
		public RateController(
			ILogger<RateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IRateRepository rateRepository,
			IRateModelValidator rateModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       rateRepository,
			       rateModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>91168e21b1cd8ea9b9f3159af489534c</Hash>
</Codenesium>*/