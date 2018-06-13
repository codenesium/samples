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
        public class ProductCategoryService: AbstractProductCategoryService, IProductCategoryService
        {
                public ProductCategoryService(
                        ILogger<ProductCategoryRepository> logger,
                        IProductCategoryRepository productCategoryRepository,
                        IApiProductCategoryRequestModelValidator productCategoryModelValidator,
                        IBOLProductCategoryMapper bolproductCategoryMapper,
                        IDALProductCategoryMapper dalproductCategoryMapper
                        ,
                        IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalProductSubcategoryMapper

                        )
                        : base(logger,
                               productCategoryRepository,
                               productCategoryModelValidator,
                               bolproductCategoryMapper,
                               dalproductCategoryMapper
                               ,
                               bolProductSubcategoryMapper,
                               dalProductSubcategoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>2fddbd6eb5dc8d6064f6d37a973c0a12</Hash>
</Codenesium>*/