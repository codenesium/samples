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
	public class ProductModelController: AbstractProductModelController
	{
		public ProductModelController(
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelRepository productModelRepository,
			IProductModelModelValidator productModelModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productModelRepository,
			       productModelModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>ac996467710e05b9c67d4279ea5273b9</Hash>
</Codenesium>*/