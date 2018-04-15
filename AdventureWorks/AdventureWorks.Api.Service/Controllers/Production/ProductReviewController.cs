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
	[Route("api/productReviews")]
	[ApiVersion("1.0")]
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
    <Hash>0ab8564c7758909f668c6d156f631624</Hash>
</Codenesium>*/