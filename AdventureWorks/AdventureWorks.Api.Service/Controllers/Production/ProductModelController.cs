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
			ITransactionCoordinator transactionCoordinator,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productModelRepository,
			         productModelModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>72c65374ba6ac829ba14ce561a4b4225</Hash>
</Codenesium>*/