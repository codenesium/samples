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
			IApiProductReviewModelValidator productReviewModelValidator)
			: base(logger, productReviewRepository, productReviewModelValidator)
		{}
	}
}

/*<Codenesium>
    <Hash>71b609d51d27fabf2bf1eb8cb21a34ab</Hash>
</Codenesium>*/