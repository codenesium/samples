using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AdventureWorksNS.Api.Web
{
	[Route("api/productReviews")]
	[ApiController]
	[ApiVersion("1.0")]

	public class ProductReviewController : AbstractProductReviewController
	{
		public ProductReviewController(
			ApiSettings settings,
			ILogger<ProductReviewController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductReviewService productReviewService,
			IApiProductReviewServerModelMapper productReviewModelMapper
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productReviewService,
			       productReviewModelMapper)
		{
			this.BulkInsertLimit = 250;
			this.MaxLimit = 1000;
			this.DefaultLimit = 250;
		}
	}
}

/*<Codenesium>
    <Hash>0a1a25082859850945266f9756f07cf8</Hash>
</Codenesium>*/