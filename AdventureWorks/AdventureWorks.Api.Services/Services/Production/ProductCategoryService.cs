using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public partial class ProductCategoryService : AbstractProductCategoryService, IProductCategoryService
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
    <Hash>559b3556742a9e743edc76a25d12a403</Hash>
</Codenesium>*/