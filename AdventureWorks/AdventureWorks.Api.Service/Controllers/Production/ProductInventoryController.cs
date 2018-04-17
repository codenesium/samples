using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productInventories")]
	[ApiVersion("1.0")]
	public class ProductInventoryController: AbstractProductInventoryController
	{
		public ProductInventoryController(
			ILogger<ProductInventoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductInventory productInventoryManager
			)
			: base(logger,
			       transactionCoordinator,
			       productInventoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>42dd36ae0b0b883dcff38a137cb9e57d</Hash>
</Codenesium>*/