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
	[Route("api/productInventories")]
	public class ProductInventoriesController: AbstractProductInventoriesController
	{
		public ProductInventoriesController(
			ILogger<ProductInventoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productInventoryRepository,
			         productInventoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ebe1de0c0fb4ecc0eb452cfe4333c417</Hash>
</Codenesium>*/