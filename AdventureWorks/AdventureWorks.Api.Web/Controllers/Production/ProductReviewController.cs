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
	[Route("api/productReviews")]
	[ApiVersion("1.0")]
	public class ProductReviewController: AbstractProductReviewController
	{
		public ProductReviewController(
			ServiceSettings settings,
			ILogger<ProductReviewController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductReviewService productReviewService
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productReviewService)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0361c0788d631c2e8f6470fdacfe00a0</Hash>
</Codenesium>*/