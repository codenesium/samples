using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ProductService: AbstractProductService, IProductService
        {
                public ProductService(
                        ILogger<ProductRepository> logger,
                        IProductRepository productRepository,
                        IApiProductRequestModelValidator productModelValidator,
                        IBOLProductMapper bolproductMapper,
                        IDALProductMapper dalproductMapper
                        ,
                        IBOLBillOfMaterialsMapper bolBillOfMaterialsMapper,
                        IDALBillOfMaterialsMapper dalBillOfMaterialsMapper
                        ,
                        IBOLProductCostHistoryMapper bolProductCostHistoryMapper,
                        IDALProductCostHistoryMapper dalProductCostHistoryMapper
                        ,
                        IBOLProductDocumentMapper bolProductDocumentMapper,
                        IDALProductDocumentMapper dalProductDocumentMapper
                        ,
                        IBOLProductInventoryMapper bolProductInventoryMapper,
                        IDALProductInventoryMapper dalProductInventoryMapper
                        ,
                        IBOLProductListPriceHistoryMapper bolProductListPriceHistoryMapper,
                        IDALProductListPriceHistoryMapper dalProductListPriceHistoryMapper
                        ,
                        IBOLProductProductPhotoMapper bolProductProductPhotoMapper,
                        IDALProductProductPhotoMapper dalProductProductPhotoMapper
                        ,
                        IBOLProductReviewMapper bolProductReviewMapper,
                        IDALProductReviewMapper dalProductReviewMapper
                        ,
                        IBOLTransactionHistoryMapper bolTransactionHistoryMapper,
                        IDALTransactionHistoryMapper dalTransactionHistoryMapper
                        ,
                        IBOLWorkOrderMapper bolWorkOrderMapper,
                        IDALWorkOrderMapper dalWorkOrderMapper

                        )
                        : base(logger,
                               productRepository,
                               productModelValidator,
                               bolproductMapper,
                               dalproductMapper
                               ,
                               bolBillOfMaterialsMapper,
                               dalBillOfMaterialsMapper
                               ,
                               bolProductCostHistoryMapper,
                               dalProductCostHistoryMapper
                               ,
                               bolProductDocumentMapper,
                               dalProductDocumentMapper
                               ,
                               bolProductInventoryMapper,
                               dalProductInventoryMapper
                               ,
                               bolProductListPriceHistoryMapper,
                               dalProductListPriceHistoryMapper
                               ,
                               bolProductProductPhotoMapper,
                               dalProductProductPhotoMapper
                               ,
                               bolProductReviewMapper,
                               dalProductReviewMapper
                               ,
                               bolTransactionHistoryMapper,
                               dalTransactionHistoryMapper
                               ,
                               bolWorkOrderMapper,
                               dalWorkOrderMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ba2719c29ff3844684499e6933e9cee0</Hash>
</Codenesium>*/