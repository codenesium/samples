using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ProductService : AbstractProductService, IProductService
        {
                public ProductService(
                        ILogger<IProductRepository> logger,
                        IProductRepository productRepository,
                        IApiProductRequestModelValidator productModelValidator,
                        IBOLProductMapper bolproductMapper,
                        IDALProductMapper dalproductMapper,
                        IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalBillOfMaterialsMapper,
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
                        IDALWorkOrderMapper dalWorkOrderMapper
                        )
                        : base(logger,
                               productRepository,
                               productModelValidator,
                               bolproductMapper,
                               dalproductMapper,
                               bolBillOfMaterialsMapper,
                               dalBillOfMaterialsMapper,
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
    <Hash>7f5f43afef95cdea1cb79212cdcf5713</Hash>
</Codenesium>*/