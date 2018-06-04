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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productCostHistories")]
	[ApiVersion("1.0")]
	public class ProductCostHistoryController: AbstractProductCostHistoryController
	{
		public ProductCostHistoryController(
			ServiceSettings settings,
			ILogger<ProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCostHistoryService productCostHistoryService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCostHistoryService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>173346fbee691eda2045e179480ad69e</Hash>
</Codenesium>*/