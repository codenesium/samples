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
	[Route("api/productModels")]
	[ApiVersion("1.0")]
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
    <Hash>9eee338da59a90834eaa602d93539fe0</Hash>
</Codenesium>*/