using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/currencyRates")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(CurrencyRateFilter))]
	public class CurrencyRateController: AbstractCurrencyRateController
	{
		public CurrencyRateController(
			ILogger<CurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateRepository currencyRateRepository
			)
			: base(logger,
			       transactionCoordinator,
			       currencyRateRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>67c184ad07bcebc4490c2c8e65ba9917</Hash>
</Codenesium>*/