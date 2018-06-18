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
                        ILogger<IProductCategoryRepository> logger,
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
    <Hash>efaa9fdbb6b30709468b344e44b6eb49</Hash>
</Codenesium>*/