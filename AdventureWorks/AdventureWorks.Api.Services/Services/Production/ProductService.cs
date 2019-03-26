using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using MediatR;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductService : AbstractProductService, IProductService
	{
		public ProductService(
			ILogger<IProductRepository> logger,
			IMediator mediator,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IDALProductMapper dalProductMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       mediator,
			       productRepository,
			       productModelValidator,
			       dalProductMapper,
			       dalBillOfMaterialMapper,
			       dalProductProductPhotoMapper,
			       dalProductReviewMapper,
			       dalTransactionHistoryMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>7434aec34ed4e384c8644807720c7911</Hash>
</Codenesium>*/