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
	[Route("api/productCategories")]
	public class ProductCategoriesController: AbstractProductCategoriesController
	{
		public ProductCategoriesController(
			ILogger<ProductCategoriesController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryRepository productCategoryRepository,
			IProductCategoryModelValidator productCategoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productCategoryRepository,
			         productCategoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>5cbc954e8a0d323d01d6cee6e2ee7eb6</Hash>
</Codenesium>*/