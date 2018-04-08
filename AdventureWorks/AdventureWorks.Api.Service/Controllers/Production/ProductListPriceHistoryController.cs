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
	public class ProductListPriceHistoriesController: AbstractProductListPriceHistoriesController
	{
		public ProductListPriceHistoriesController(
			ILogger<ProductListPriceHistoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productListPriceHistoryRepository,
			         productListPriceHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>57ea3e77275ebec9017160163fad3ff1</Hash>
</Codenesium>*/