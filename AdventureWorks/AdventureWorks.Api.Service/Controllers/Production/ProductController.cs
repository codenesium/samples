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
	public class ProductsController: AbstractProductsController
	{
		public ProductsController(
			ILogger<ProductsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductRepository productRepository,
			IProductModelValidator productModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productRepository,
			         productModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>a9ddbd7c3c91a95fc5c563c87a654dbc</Hash>
</Codenesium>*/