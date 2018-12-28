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
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper)
			: base(logger,
			       mediator,
			       productReviewRepository,
			       productReviewModelValidator,
			       bolProductReviewMapper,
			       dalProductReviewMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>17cf0ab09683ed93d715975c79a43ab7</Hash>
</Codenesium>*/