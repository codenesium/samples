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
	[Route("api/productDescriptions")]
	[ApiVersion("1.0")]
	public class ProductDescriptionController: AbstractProductDescriptionController
	{
		public ProductDescriptionController(
			ServiceSettings settings,
			ILogger<ProductDescriptionController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductDescriptionService productDescriptionService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productDescriptionService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>c68f84dfcbbc2b4fb570f4ff78b28714</Hash>
</Codenesium>*/