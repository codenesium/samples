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
	[Route("api/countryRegionCurrencies")]
	[ApiVersion("1.0")]
	[ResponseFilter]
	public class CountryRegionCurrencyController: AbstractCountryRegionCurrencyController
	{
		public CountryRegionCurrencyController(
			ILogger<CountryRegionCurrencyController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOCountryRegionCurrency countryRegionCurrencyManager
			)
			: base(logger,
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
    <Hash>a3dceeb557d57eea1c67e81ed631b252</Hash>
</Codenesium>*/