using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productInventories")]
	[ApiVersion("1.0")]
	[Response]
	public class ProductInventoryController: AbstractProductInventoryController
	{
		public ProductInventoryController(
			ServiceSettings settings,
			ILogger<ProductInventoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductInventory productInventoryManager
			)
			: base(settings,
			       logger,
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
    <Hash>c41ff55868370b13384eb300e8aefab8</Hash>
</Codenesium>*/