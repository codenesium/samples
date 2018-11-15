using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/salesTaxRates")]
	[ApiController]
	[ApiVersion("1.0")]
	[Authorize(Policy = "DefaultAccess")]

	public class SalesTaxRateController : AbstractSalesTaxRateController
	{
		public SalesTaxRateController(
			ApiSettings settings,
			ILogger<SalesTaxRateController> logger,
			ITransactionCoordinator transactionCoordinator,
			ISalesTaxRateService salesTaxRateService,
			IApiSalesTaxRateServerModelMapper salesTaxRateModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       salesTaxRateService,
			       salesTaxRateModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>41e3a586639072c59f4106337e3b4553</Hash>
</Codenesium>*/