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
	[Route("api/currencyRates")]
	public class CurrencyRatesController: AbstractCurrencyRatesController
	{
		public CurrencyRatesController(
			ILogger<CurrencyRatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator
			) : base(logger,
			         transactionCoordinator,
			         currencyRateRepository,
			         currencyRateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e0b86f1f17fc337a9b941800f0945804</Hash>
</Codenesium>*/