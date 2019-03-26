using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductReviewService : AbstractProductReviewService, IProductReviewService
	{
		public ProductReviewService(
			ILogger<IProductReviewRepository> logger,
			IMediator mediator,
			IProductReviewRepository productReviewRepository,
			IApiProductReviewServerRequestModelValidator productReviewModelValidator,
			IDALProductReviewMapper dalProductReviewMapper)
			: base(logger,
			       mediator,
			       productReviewRepository,
			       productReviewModelValidator,
			       dalProductReviewMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f37494c4ef823ddda390be6fe58d7f0a</Hash>
</Codenesium>*/