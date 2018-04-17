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
	[Route("api/currencyRates")]
	[ApiVersion("1.0")]
	public class CurrencyRateController: AbstractCurrencyRateController
	{
		public CurrencyRateController(
			ILogger<CurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCurrencyRate currencyRateManager
			)
			: base(logger,
			       transactionCoordinator,
			       currencyRateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>213ba9c1479c7747acc936e7c6e15d9f</Hash>
</Codenesium>*/