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
			ApplicationContext context,
			IProductInventoryRepository productInventoryRepository,
			IProductInventoryModelValidator productInventoryModelValidator
			) : base(logger,
			         context,
			         productInventoryRepository,
			         productInventoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a85b4b475e368ad87837b5777ded7589</Hash>
</Codenesium>*/