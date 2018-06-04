using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productModels")]
	[ApiVersion("1.0")]
	public class ProductModelController: AbstractProductModelController
	{
		public ProductModelController(
			ServiceSettings settings,
			ILogger<ProductModelController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelService productModelService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>4a7a0d8e8523ad3b09b99e3c7a68a60a</Hash>
</Codenesium>*/