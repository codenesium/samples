using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
	public class ProductReviewService: AbstractProductReviewService, IProductReviewService
	{
		public ProductReviewService(
			ILogger<ProductReviewRepository> logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper BOLproductReviewMapper,
			IDALProductReviewMapper DALproductReviewMapper)
			: base(logger, productReviewRepository,
			       productReviewModelValidator,
			       BOLproductReviewMapper,
			       DALproductReviewMapper)
		{}
	}
}

/*<Codenesium>
    <Hash>2e1a0ecdcb00e2079bf1e30d41d3d5f9</Hash>
</Codenesium>*/