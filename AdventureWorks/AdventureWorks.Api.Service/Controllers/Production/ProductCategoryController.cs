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
	public class ProductCategoryController: AbstractProductCategoryController
	{
		public ProductCategoryController(
			ILogger<ProductCategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductCategoryRepository productCategoryRepository,
			IProductCategoryModelValidator productCategoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productCategoryRepository,
			       productCategoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>aea9cbc104dd82c6c8e3041643a44352</Hash>
</Codenesium>*/