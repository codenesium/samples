using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductReviewService : AbstractProductReviewService, IProductReviewService
	{
		public ProductReviewService(
			ILogger<IProductReviewRepository> logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper bolproductReviewMapper,
			IDALProductReviewMapper dalproductReviewMapper
			)
			: base(logger,
			       productReviewRepository,
			       productReviewModelValidator,
			       bolproductReviewMapper,
			       dalproductReviewMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c11ed33c1ce8addca31035166956bf71</Hash>
</Codenesium>*/