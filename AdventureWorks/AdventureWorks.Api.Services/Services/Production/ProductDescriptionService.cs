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
                        IDALProductDescriptionMapper dalproductDescriptionMapper
                        ,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper

                        )
                        : base(logger,
                               productDescriptionRepository,
                               productDescriptionModelValidator,
                               bolproductDescriptionMapper,
                               dalproductDescriptionMapper
                               ,
                               bolProductModelProductDescriptionCultureMapper,
                               dalProductModelProductDescriptionCultureMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>e44fe5523fc35808ab45f66c206d20aa</Hash>
</Codenesium>*/