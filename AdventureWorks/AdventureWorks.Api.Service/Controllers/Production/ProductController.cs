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
	[Route("api/products")]
	[ApiVersion("1.0")]
	[ServiceFilter(typeof(ProductFilter))]
	public class ProductController: AbstractProductController
	{
		public ProductController(
			ILogger<ProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductRepository productRepository
			)
			: base(logger,
			       transactionCoordinator,
			       productRepository)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>abd5daeb0e37efa6b4febd1bb674b37d</Hash>
</Codenesium>*/