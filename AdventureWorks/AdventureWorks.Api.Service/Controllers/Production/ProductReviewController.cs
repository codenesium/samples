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
			ApplicationContext context,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator
			) : base(logger,
			         context,
			         productReviewRepository,
			         productReviewModelValidator)
		{
			this.SearchRecordLimit = 1000;
			this.SearchRecordDefault = 250;
		}
	}
}

/*<Codenesium>
    <Hash>bacf787d7b38a9cc3a3e8ed577f4d0c3</Hash>
</Codenesium>*/