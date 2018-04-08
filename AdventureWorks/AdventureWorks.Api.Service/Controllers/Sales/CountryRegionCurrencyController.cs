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
	[Route("api/countryRegionCurrencies")]
	public class CountryRegionCurrenciesController: AbstractCountryRegionCurrenciesController
	{
		public CountryRegionCurrenciesController(
			ILogger<CountryRegionCurrenciesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			) : base(logger,
			         transactionCoordinator,
			         countryRegionCurrencyRepository,
			         countryRegionCurrencyModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>03bfc5b1cea4e2eb888215552029b767</Hash>
</Codenesium>*/