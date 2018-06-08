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
                        IDALProductCategoryMapper dalproductCategoryMapper)
                        : base(logger,
                               productCategoryRepository,
                               productCategoryModelValidator,
                               bolproductCategoryMapper,
                               dalproductCategoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4958ec8ec5d7cce47be2c1c5d20b9aa6</Hash>
</Codenesium>*/