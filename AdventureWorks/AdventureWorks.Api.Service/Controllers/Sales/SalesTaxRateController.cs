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
	[Route("api/salesTaxRates")]
	[ApiVersion("1.0")]
	[Response]
	public class SalesTaxRateController: AbstractSalesTaxRateController
	{
		public SalesTaxRateController(
			ServiceSettings settings,
			ILogger<SalesTaxRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOSalesTaxRate salesTaxRateManager
			)
			: base(settings,
			       logger,
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
    <Hash>8e345ede9af36467807f6e7e2e92d6fc</Hash>
</Codenesium>*/