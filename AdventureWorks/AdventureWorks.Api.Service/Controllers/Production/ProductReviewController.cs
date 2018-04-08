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
	public class ProductReviewsController: AbstractProductReviewsController
	{
		public ProductReviewsController(
			ILogger<ProductReviewsController> logger,
			ITransactionCoordinator transactionCoordinator,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator
			) : base(logger,
			         transactionCoordinator,
			         productReviewRepository,
			         productReviewModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>f54161fb13f3cb0e041757ae61cdbfde</Hash>
</Codenesium>*/