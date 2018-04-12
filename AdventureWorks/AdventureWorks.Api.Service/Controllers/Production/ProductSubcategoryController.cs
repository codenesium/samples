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
	public class ProductSubcategoryController: AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryRepository productSubcategoryRepository,
			IProductSubcategoryModelValidator productSubcategoryModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productSubcategoryRepository,
			       productSubcategoryModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>7842d7e7d0d7f64d71859fa1ee4662fd</Hash>
</Codenesium>*/