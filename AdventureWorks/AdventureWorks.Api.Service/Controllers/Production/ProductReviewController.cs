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
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productReviews")]
	[ApiVersion("1.0")]
	public class ProductReviewController: AbstractProductReviewController
	{
		public ProductReviewController(
			ServiceSettings settings,
			ILogger<ProductReviewController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductReview productReviewManager
			)
			: base(settings,
			       logger,
			       transactionCoordinator,
			       productReviewManager)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>cd7d247efaad7f026785d3beab70540d</Hash>
</Codenesium>*/