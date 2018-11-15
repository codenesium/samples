using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductReviewService : AbstractProductReviewService, IProductReviewService
	{
		public ProductReviewService(
			ILogger<IProductReviewRepository> logger,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewServerRequestModelValidator productReviewModelValidator,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper)
			: base(logger,
			       productReviewRepository,
			       productReviewModelValidator,
			       bolProductReviewMapper,
			       dalProductReviewMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>a1804c26319e72e7caebcf084b87280b</Hash>
</Codenesium>*/