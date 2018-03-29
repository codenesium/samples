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
			ApplicationContext context,
			IProductCategoryRepository productCategoryRepository,
			IProductCategoryModelValidator productCategoryModelValidator
			) : base(logger,
			         context,
			         productCategoryRepository,
			         productCategoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>545a3918d7acb9603ddfdf3cb78cde00</Hash>
</Codenesium>*/