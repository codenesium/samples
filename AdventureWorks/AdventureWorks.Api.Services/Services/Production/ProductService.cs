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
	public partial class ProductService : AbstractProductService, IProductService
	{
		public ProductService(
			ILogger<IProductRepository> logger,
			IProductRepository productRepository,
			IApiProductRequestModelValidator productModelValidator,
			IBOLProductMapper bolproductMapper,
			IDALProductMapper dalproductMapper,
			IBOLBillOfMaterialMapper bolBillOfMaterialMapper,
			IDALBillOfMaterialMapper dalBillOfMaterialMapper,
			IBOLProductCostHistoryMapper bolProductCostHistoryMapper,
			IDALProductCostHistoryMapper dalProductCostHistoryMapper,
			IBOLProductInventoryMapper bolProductInventoryMapper,
			IDALProductInventoryMapper dalProductInventoryMapper,
			IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper,
			IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper,
			IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
			IDALProductProductPhotoMapper dalProductProductPhotoMapper,
			IBOLProductReviewMapper bolProductReviewMapper,
			IDALProductReviewMapper dalProductReviewMapper,
			IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
			IDALTransactionHistoryMapper dalTransactionHistoryMapper,
			IBOLWorkOrderMapper bolWorkOrderMapper,
			IDALWorkOrderMapper dalWorkOrderMapper)
			: base(logger,
			       productRepository,
			       productModelValidator,
			       bolproductMapper,
			       dalproductMapper,
			       bolBillOfMaterialMapper,
			       dalBillOfMaterialMapper,
			       bolProductCostHistoryMapper,
			       dalProductCostHistoryMapper,
			       bolProductInventoryMapper,
			       dalProductInventoryMapper,
			       bolProductListPriceHistoryMapper,
			       dalProductListPriceHistoryMapper,
			       bolProductProductPhotoMapper,
			       dalProductProductPhotoMapper,
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
    <Hash>bc026fe0d3e1466d1d0faa2ca844eb8c</Hash>
</Codenesium>*/