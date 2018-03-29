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
			ApplicationContext context,
			IProductRepository productRepository,
			IProductModelValidator productModelValidator
			) : base(logger,
			         context,
			         productRepository,
			         productModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>80c4496b30a3b8b3420c68fc54f1d49e</Hash>
</Codenesium>*/