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
			ITransactionCoordinator transactionCoordinator,
			IProductCostHistoryRepository productCostHistoryRepository,
			IProductCostHistoryModelValidator productCostHistoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productCostHistoryRepository,
			         productCostHistoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>eebdc7e77ee846466489083fb67257c0</Hash>
</Codenesium>*/