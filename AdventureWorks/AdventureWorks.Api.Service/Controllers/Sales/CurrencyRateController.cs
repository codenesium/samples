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
			ApplicationContext context,
			ICurrencyRateRepository currencyRateRepository,
			ICurrencyRateModelValidator currencyRateModelValidator
			) : base(logger,
			         context,
			         currencyRateRepository,
			         currencyRateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>3d39cf3cc4a05f925805f3b40d3dcf0f</Hash>
</Codenesium>*/