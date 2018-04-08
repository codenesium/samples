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
	[Route("api/salesTaxRates")]
	public class SalesTaxRatesController: AbstractSalesTaxRatesController
	{
		public SalesTaxRatesController(
			ILogger<SalesTaxRatesController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator
			) : base(logger,
			         transactionCoordinator,
			         salesTaxRateRepository,
			         salesTaxRateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a4e62e01d50bbc954119539daf7ec273</Hash>
</Codenesium>*/