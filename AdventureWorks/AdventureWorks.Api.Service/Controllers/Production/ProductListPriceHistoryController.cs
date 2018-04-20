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
	[Route("api/productListPriceHistories")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductListPriceHistoryController: AbstractProductListPriceHistoryController
	{
		public ProductListPriceHistoryController(
			ServiceSettings settings,
			ILogger<ProductListPriceHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductListPriceHistory productListPriceHistoryManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productListPriceHistoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2ee12d1625d98c450f1c37b8a8327b03</Hash>
</Codenesium>*/