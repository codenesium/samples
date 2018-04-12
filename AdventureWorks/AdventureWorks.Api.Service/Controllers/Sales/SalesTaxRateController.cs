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
	public class SalesTaxRateController: AbstractSalesTaxRateController
	{
		public SalesTaxRateController(
			ILogger<SalesTaxRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTaxRateRepository salesTaxRateRepository,
			ISalesTaxRateModelValidator salesTaxRateModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       salesTaxRateRepository,
			       salesTaxRateModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>802e354a95154e63ad85f306e2911456</Hash>
</Codenesium>*/