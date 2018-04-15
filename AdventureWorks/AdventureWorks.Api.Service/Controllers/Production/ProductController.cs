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
	public class ProductController: AbstractProductController
	{
		public ProductController(
			ILogger<ProductController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductRepository productRepository,
			IProductModelValidator productModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productRepository,
			       productModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>b36930d0df9e15a86f54434a8c24f346</Hash>
</Codenesium>*/