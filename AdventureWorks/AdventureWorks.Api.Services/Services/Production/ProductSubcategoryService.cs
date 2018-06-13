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
        public class ProductSubcategoryService: AbstractProductSubcategoryService, IProductSubcategoryService
        {
                public ProductSubcategoryService(
                        ILogger<ProductSubcategoryRepository> logger,
                        IProductSubcategoryRepository productSubcategoryRepository,
                        IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
                        IBOLProductSubcategoryMapper bolproductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalproductSubcategoryMapper
                        ,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper

                        )
                        : base(logger,
                               productSubcategoryRepository,
                               productSubcategoryModelValidator,
                               bolproductSubcategoryMapper,
                               dalproductSubcategoryMapper
                               ,
                               bolProductMapper,
                               dalProductMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>1f9eb356377d87a94c1048602548e3b7</Hash>
</Codenesium>*/