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
	[Route("api/productListPriceHistories")]
	public class ProductListPriceHistoryController: AbstractProductListPriceHistoryController
	{
		public ProductListPriceHistoryController(
			ILogger<ProductListPriceHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productListPriceHistoryRepository,
			       productListPriceHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>2927fd79bb9873ce93678dd0591e6691</Hash>
</Codenesium>*/