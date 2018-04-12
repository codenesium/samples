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
	public class CountryRegionCurrencyController: AbstractCountryRegionCurrencyController
	{
		public CountryRegionCurrencyController(
			ILogger<CountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository,
			ICountryRegionCurrencyModelValidator countryRegionCurrencyModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       countryRegionCurrencyRepository,
			       countryRegionCurrencyModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2dc2e4bdf447087d06a2e05b5738e538</Hash>
</Codenesium>*/