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
	public class ProductCostHistoryController: AbstractProductCostHistoryController
	{
		public ProductCostHistoryController(
			ILogger<ProductCostHistoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productCostHistoryRepository,
			       productCostHistoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>826101bf8a20ecd43b4d5c50dfb93d39</Hash>
</Codenesium>*/