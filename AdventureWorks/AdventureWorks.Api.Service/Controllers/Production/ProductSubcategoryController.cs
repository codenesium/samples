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
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productSubcategoryRepository,
			         productSubcategoryModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>82fe762bb42f9be0983526bba38b65bb</Hash>
</Codenesium>*/