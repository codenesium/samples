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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/countryRegionCurrencies")]
	[ApiVersion("1.0")]
	[Response]
	public class CountryRegionCurrencyController: AbstractCountryRegionCurrencyController
	{
		public CountryRegionCurrencyController(
			ServiceSettings settings,
			ILogger<CountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegionCurrency countryRegionCurrencyManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       countryRegionCurrencyManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>fdfe2b7b4087246db03a7c08fc1a3b87</Hash>
</Codenesium>*/