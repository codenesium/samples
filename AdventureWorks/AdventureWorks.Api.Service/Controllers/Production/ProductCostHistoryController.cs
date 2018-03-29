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
	[Route("api/productCostHistories")]
	public class ProductCostHistoriesController: AbstractProductCostHistoriesController
	{
		public ProductCostHistoriesController(
			ILogger<ProductCostHistoriesController> logger,
			ApplicationContext context,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator
			) : base(logger,
			         context,
			         productCostHistoryRepository,
			         productCostHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d70a9620e1fe0647389dde900c261029</Hash>
</Codenesium>*/