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
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productCategories")]
	[ApiVersion("1.0")]
	public class ProductCategoryController: AbstractProductCategoryController
	{
		public ProductCategoryController(
			ServiceSettings settings,
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryService productCategoryService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productCategoryService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>58d399b5658c2161af43a2494e6a58cc</Hash>
</Codenesium>*/