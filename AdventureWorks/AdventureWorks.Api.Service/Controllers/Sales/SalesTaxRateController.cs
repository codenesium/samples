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
			ApplicationContext context,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator
			) : base(logger,
			         context,
			         salesTaxRateRepository,
			         salesTaxRateModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>de590633a200f325acc81734861ca0f9</Hash>
</Codenesium>*/