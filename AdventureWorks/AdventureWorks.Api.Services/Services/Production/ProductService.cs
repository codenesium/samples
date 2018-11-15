using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Microsoft.Extensions.Logging;

namespace AdventureWorksNS.Api.Services
{
	public partial class ProductService : AbstractProductService, IProductService
	{
		public ProductService(
			ILogger<IProductRepository> logger,
			IProductRepository productRepository,
			IApiProductServerRequestModelValidator productModelValidator,
			IBOLProductMapper bolProductMapper,
			IDALProductMapper dalProductMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       productRepository,
			       productModelValidator,
			       bolProductMapper,
			       dalProductMapper,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper,
			       bolProductReviewMapper,
			       dalProductReviewMapper,
			       bolTransactionHistoryMapper,
			       dalTransactionHistoryMapper,
			       bolWorkOrderMapper,
			       dalWorkOrderMapper)
		{
		}
	}
}

/*<Codenesium>
    <Hash>f50aec149a3addc06ea26193ceaaddac</Hash>
</Codenesium>*/