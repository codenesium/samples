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
        public class ProductDescriptionService : AbstractProductDescriptionService, IProductDescriptionService
        {
                public ProductDescriptionService(
                        ILogger<IProductDescriptionRepository> logger,
                        IProductDescriptionRepository productDescriptionRepository,
                        IApiProductDescriptionRequestModelValidator productDescriptionModelValidator,
                        IBOLProductDescriptionMapper bolproductDescriptionMapper,
                        IDALProductDescriptionMapper dalproductDescriptionMapper,
                        IBOLProductModelProductDescriptionCultureMapper bolProductModelProductDescriptionCultureMapper,
                        IDALProductModelProductDescriptionCultureMapper dalProductModelProductDescriptionCultureMapper
                        )
                        : base(logger,
                               productDescriptionRepository,
                               productDescriptionModelValidator,
                               bolproductDescriptionMapper,
                               dalproductDescriptionMapper,
                               bolProductModelProductDescriptionCultureMapper,
                               dalProductModelProductDescriptionCultureMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>dab65fe74120145cec642645150394ce</Hash>
</Codenesium>*/