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
	[Route("api/productModels")]
	public class ProductModelsController: AbstractProductModelsController
	{
		public ProductModelsController(
			ILogger<ProductModelsController> logger,
			ApplicationContext context,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator
			) : base(logger,
			         context,
			         productModelRepository,
			         productModelModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f652c78eb5ebad6dea0bc9126ebb3254</Hash>
</Codenesium>*/