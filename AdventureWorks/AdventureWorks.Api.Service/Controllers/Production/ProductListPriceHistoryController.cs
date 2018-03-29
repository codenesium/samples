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
			ApplicationContext context,
			IProductListPriceHistoryRepository productListPriceHistoryRepository,
			IProductListPriceHistoryModelValidator productListPriceHistoryModelValidator
			) : base(logger,
			         context,
			         productListPriceHistoryRepository,
			         productListPriceHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7142b9697298f68cad83957ec8d0e9d1</Hash>
</Codenesium>*/