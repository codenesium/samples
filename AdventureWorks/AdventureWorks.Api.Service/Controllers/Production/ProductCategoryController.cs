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
	[Route("api/productCategories")]
	[ApiVersion("1.0")]
	public class ProductCategoryController: AbstractProductCategoryController
	{
		public ProductCategoryController(
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductCategory productCategoryManager
			)
			: base(logger,
			       transactionCoordinator,
			       productCategoryManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>e556be40d86034eacfdc8e56ff17b3bc</Hash>
</Codenesium>*/