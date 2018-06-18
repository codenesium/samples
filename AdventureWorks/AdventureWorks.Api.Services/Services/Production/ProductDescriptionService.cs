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
                        ILogger<IProductDescriptionRepository> logger,
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
    <Hash>dd7fea09381b636e70f0110e1a84241a</Hash>
</Codenesium>*/