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
                        IDALProductSubcategoryMapper dalproductSubcategoryMapper)
                        : base(logger,
                               productSubcategoryRepository,
                               productSubcategoryModelValidator,
                               bolproductSubcategoryMapper,
                               dalproductSubcategoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ab7db3408ec6d806c3a5ab522136e926</Hash>
</Codenesium>*/