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
	[Route("api/productCategories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductCategoryFilter))]
	public class ProductCategoryController: AbstractProductCategoryController
	{
		public ProductCategoryController(
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryRepository productCategoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productCategoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6512663088e1edb21595625c6bc5d686</Hash>
</Codenesium>*/