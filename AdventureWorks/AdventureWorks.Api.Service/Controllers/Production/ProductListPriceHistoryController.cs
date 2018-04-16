using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productListPriceHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductListPriceHistoryFilter))]
	public class ProductListPriceHistoryController: AbstractProductListPriceHistoryController
	{
		public ProductListPriceHistoryController(
			ILogger<ProductListPriceHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductListPriceHistoryRepository productListPriceHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productListPriceHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7e0bd11f6cdd517b8a582cca959543ce</Hash>
</Codenesium>*/