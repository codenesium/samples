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
	[Route("api/countryRegionCurrencies")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(CountryRegionCurrencyFilter))]
	public class CountryRegionCurrencyController: AbstractCountryRegionCurrencyController
	{
		public CountryRegionCurrencyController(
			ILogger<CountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			ICountryRegionCurrencyRepository countryRegionCurrencyRepository
			)
			: base(logger,
			       transactionCoordinator,
			       countryRegionCurrencyRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>8cb08a6b40bdc49b73233887631ef57f</Hash>
</Codenesium>*/