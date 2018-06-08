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
        public class ProductDescriptionService: AbstractProductDescriptionService, IProductDescriptionService
        {
                public ProductDescriptionService(
                        ILogger<ProductDescriptionRepository> logger,
                        IProductDescriptionRepository productDescriptionRepository,
                        IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
                        IBOLProductDescriptionMapper bolproductDescriptionMapper,
                        IDALProductDescriptionMapper dalproductDescriptionMapper)
                        : base(logger,
                               productDescriptionRepository,
                               productDescriptionModelValidator,
                               bolproductDescriptionMapper,
                               dalproductDescriptionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>273ba52c0169ddb7edd2436d02f63b7a</Hash>
</Codenesium>*/