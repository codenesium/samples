using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.BusinessObjects
{
	public class BOProductReview: AbstractBOProductReview, IBOProductReview
	{
		public BOProductReview(
			ILogger<ProductReviewRepository> logger,
			IProductReviewRepository productReviewRepository,
			IProductReviewModelValidator productReviewModelValidator)
			: base(logger, productReviewRepository, productReviewModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>6af4181635ba1df460341c9be801beaf</Hash>
</Codenesium>*/