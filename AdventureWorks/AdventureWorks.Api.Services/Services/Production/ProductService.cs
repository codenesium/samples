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
                        IDALProductMapper dalproductMapper)
                        : base(logger,
                               productRepository,
                               productModelValidator,
                               bolproductMapper,
                               dalproductMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>46322777a0de5b5b2a59bd20853114ad</Hash>
</Codenesium>*/