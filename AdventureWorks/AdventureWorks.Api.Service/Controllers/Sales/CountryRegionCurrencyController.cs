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
			ApplicationContext context,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			) : base(logger,
			         context,
			         countryRegionCurrencyRepository,
			         countryRegionCurrencyModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>04d847da83b76c715524bde238da34b5</Hash>
</Codenesium>*/