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
	[ResponseFilter]
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
    <Hash>1bb5bbd6bd45f3b0e5890b1a6d0b034e</Hash>
</Codenesium>*/