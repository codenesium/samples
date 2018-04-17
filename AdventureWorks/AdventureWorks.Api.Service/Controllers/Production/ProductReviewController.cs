using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.BusinessObjects;

namespace AdventureWorksNS.Api.Service
{
	[Route("api/productReviews")]
	[ApiVersion("1.0")]
	public class ProductReviewController: AbstractProductReviewController
	{
		public ProductReviewController(
			ILogger<ProductReviewController> logger,
			ITransactionCoordinator transactionCoordinator,
			IBOProductReview productReviewManager
			)
			: base(logger,
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
    <Hash>5e5b0e0fe9d8f3de7460bc25f086a9af</Hash>
</Codenesium>*/