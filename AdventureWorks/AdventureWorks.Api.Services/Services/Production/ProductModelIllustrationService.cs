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
        public class ProductModelIllustrationService: AbstractProductModelIllustrationService, IProductModelIllustrationService
        {
                public ProductModelIllustrationService(
                        ILogger<ProductModelIllustrationRepository> logger,
                        IProductModelIllustrationRepository productModelIllustrationRepository,
                        IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
                        IBOLProductModelIllustrationMapper bolproductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalproductModelIllustrationMapper)
                        : base(logger,
                               productModelIllustrationRepository,
                               productModelIllustrationModelValidator,
                               bolproductModelIllustrationMapper,
                               dalproductModelIllustrationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>fab60e79e5ca37f75d08b6cfd6d12212</Hash>
</Codenesium>*/