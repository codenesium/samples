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
        public class ProductSubcategoryService : AbstractProductSubcategoryService, IProductSubcategoryService
        {
                public ProductSubcategoryService(
                        ILogger<IProductSubcategoryRepository> logger,
                        IProductSubcategoryRepository productSubcategoryRepository,
                        IApiProductSubcategoryRequestModelValidator productSubcategoryModelValidator,
                        IBOLProductSubcategoryMapper bolproductSubcategoryMapper,
                        IDALProductSubcategoryMapper dalproductSubcategoryMapper,
                        IBOLProductMapper bolProductMapper,
                        IDALProductMapper dalProductMapper
                        )
                        : base(logger,
                               productSubcategoryRepository,
                               productSubcategoryModelValidator,
                               bolproductSubcategoryMapper,
                               dalproductSubcategoryMapper,
                               bolProductMapper,
                               dalProductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6617a1e96cd79d82098f6ef035efb71e</Hash>
</Codenesium>*/