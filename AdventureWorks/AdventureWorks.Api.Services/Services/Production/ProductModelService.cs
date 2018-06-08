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
        public class ProductModelService: AbstractProductModelService, IProductModelService
        {
                public ProductModelService(
                        ILogger<ProductModelRepository> logger,
                        IProductModelRepository productModelRepository,
                        IApiProductModelRequestModelValidator productModelModelValidator,
                        IBOLProductModelMapper bolproductModelMapper,
                        IDALProductModelMapper dalproductModelMapper)
                        : base(logger,
                               productModelRepository,
                               productModelModelValidator,
                               bolproductModelMapper,
                               dalproductModelMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>46d9805013f32b12d80a980a85193d74</Hash>
</Codenesium>*/