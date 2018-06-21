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
        public class ProductModelIllustrationService : AbstractProductModelIllustrationService, IProductModelIllustrationService
        {
                public ProductModelIllustrationService(
                        ILogger<IProductModelIllustrationRepository> logger,
                        IProductModelIllustrationRepository productModelIllustrationRepository,
                        IApiProductModelIllustrationRequestModelValidator productModelIllustrationModelValidator,
                        IBOLProductModelIllustrationMapper bolproductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalproductModelIllustrationMapper
                        )
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
    <Hash>050af9333d8de79e7e3bffe86626790d</Hash>
</Codenesium>*/