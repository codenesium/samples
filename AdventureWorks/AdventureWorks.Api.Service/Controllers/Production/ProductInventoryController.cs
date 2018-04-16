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
	[Route("api/productInventories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductInventoryFilter))]
	public class ProductInventoryController: AbstractProductInventoryController
	{
		public ProductInventoryController(
			ILogger<ProductInventoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductInventoryRepository productInventoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productInventoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c55f68bd7aff2cd6e0bc6adc8cb574ef</Hash>
</Codenesium>*/