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
	[Route("api/products")]
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
    <Hash>d557dbc750ab0279847b7c7d459c40ca</Hash>
</Codenesium>*/