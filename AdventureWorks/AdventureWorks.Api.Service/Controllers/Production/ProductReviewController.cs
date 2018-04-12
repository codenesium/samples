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
	[Route("api/productReviews")]
	public class ProductReviewController: AbstractProductReviewController
	{
		public ProductReviewController(
			ILogger<ProductReviewController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator
			)
			: base(logger,
			       transactionCoordinator,
			       productReviewRepository,
			       productReviewModelValidator)
		{
			this.BulkInsertLimit = 250;
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>6680d386c07c5b2c419b63c80d5640ee</Hash>
</Codenesium>*/