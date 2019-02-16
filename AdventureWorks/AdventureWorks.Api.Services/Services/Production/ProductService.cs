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
			IDALProductReviewMapper dalProductReviewMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       mediator,
			       productRepository,
			       productModelValidator,
			       dalProductMapper,
			       dalBillOfMaterialMapper,
			       dalProductReviewMapper,
			       dalTransactionHistoryMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>c506ea1080f513d7ee70befc3d8e2dac</Hash>
</Codenesium>*/