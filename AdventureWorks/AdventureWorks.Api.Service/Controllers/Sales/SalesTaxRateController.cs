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
	[Route("api/salesTaxRates")]
	[ApiVersion("1.0")]
	public class SalesTaxRateController: AbstractSalesTaxRateController
	{
		public SalesTaxRateController(
			ILogger<SalesTaxRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTaxRate salesTaxRateManager
			)
			: base(logger,
			       transactionCoordinator,
			       salesTaxRateManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0169080b5de16150773a9ff096794f70</Hash>
</Codenesium>*/