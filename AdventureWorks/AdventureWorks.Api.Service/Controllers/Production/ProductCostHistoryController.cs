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
	[Route("api/productCostHistories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductCostHistoryFilter))]
	public class ProductCostHistoryController: AbstractProductCostHistoryController
	{
		public ProductCostHistoryController(
			ILogger<ProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCostHistoryRepository productCostHistoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productCostHistoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a8f3b23db3f619e4c0ee32a991d625e6</Hash>
</Codenesium>*/