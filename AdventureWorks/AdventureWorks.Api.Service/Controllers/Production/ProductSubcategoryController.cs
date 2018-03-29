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
	[Route("api/productSubcategories")]
	public class ProductSubcategoriesController: AbstractProductSubcategoriesController
	{
		public ProductSubcategoriesController(
			ILogger<ProductSubcategoriesController> logger,
			ApplicationContext context,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator
			) : base(logger,
			         context,
			         productSubcategoryRepository,
			         productSubcategoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bf0b8b8877065484fb862eac395d7cf2</Hash>
</Codenesium>*/