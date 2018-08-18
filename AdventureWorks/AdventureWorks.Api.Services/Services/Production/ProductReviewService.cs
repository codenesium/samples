using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using System.Threading.Tasks;

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
    <Hash>360b28fa33947b8306aade505574f7b8</Hash>
</Codenesium>*/