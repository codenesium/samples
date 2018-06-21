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
        public class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
        {
                public ProductCategoryService(
                        ILogger<IProductCategoryRepository> logger,
                        IProductCategoryRepository productCategoryRepository,
                        IApiProductCategoryRequestModelValidator productCategoryModelValidator,
                        IBOLProductCategoryMapper bolproductCategoryMapper,
                        IDALProductCategoryMapper dalproductCategoryMapper,
                        IBOLProductSubcategoryMapper bolProductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalProductSubcategoryMapper
                        )
                        : base(logger,
                               productCategoryRepository,
                               productCategoryModelValidator,
                               bolproductCategoryMapper,
                               dalproductCategoryMapper,
                               bolProductSubcategoryMapper,
                               dalProductSubcategoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b058950887a00bcae1b14fd3bf16a947</Hash>
</Codenesium>*/