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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/currencyRates")]
	[ApiVersion("1.0")]
	public class CurrencyRateController: AbstractCurrencyRateController
	{
		public CurrencyRateController(
			ServiceSettings settings,
			ILogger<CurrencyRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateService currencyRateService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       currencyRateService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>83357b2bfbae34c3662f534096615fd3</Hash>
</Codenesium>*/