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
	[Route("api/productSubcategories")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductSubcategoryFilter))]
	public class ProductSubcategoryController: AbstractProductSubcategoryController
	{
		public ProductSubcategoryController(
			ILogger<ProductSubcategoryController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductSubcategoryRepository productSubcategoryRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productSubcategoryRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ff5022b09bbd0c240c37b3a9da84d1c4</Hash>
</Codenesium>*/