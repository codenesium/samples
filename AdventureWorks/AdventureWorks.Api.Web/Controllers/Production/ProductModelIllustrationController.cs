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
	[Route("api/productModelIllustrations")]
	[ApiVersion("1.0")]
	public class ProductModelIllustrationController: AbstractProductModelIllustrationController
	{
		public ProductModelIllustrationController(
			ServiceSettings settings,
			ILogger<ProductModelIllustrationController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductModelIllustrationService productModelIllustrationService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productModelIllustrationService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>d87fc57c5e8ba488bb5d7151d95b156b</Hash>
</Codenesium>*/