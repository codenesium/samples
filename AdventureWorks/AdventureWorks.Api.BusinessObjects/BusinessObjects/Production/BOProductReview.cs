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
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper productReviewMapper)
			: base(logger, productReviewRepository, productReviewModelValidator, productReviewMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>184d11224397777efa8b40b64d59e23f</Hash>
</Codenesium>*/