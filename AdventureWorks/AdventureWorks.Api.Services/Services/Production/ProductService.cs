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
                        ILogger<IProductRepository> logger,
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
    <Hash>c54523977c897b84c127c670930f0c05</Hash>
</Codenesium>*/