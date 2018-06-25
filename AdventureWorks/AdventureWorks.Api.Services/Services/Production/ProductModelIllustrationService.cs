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
        public partial class ProductModelIllustrationService : AbstractProductModelIllustrationService, IProductModelIllustrationService
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
    <Hash>da370eaaceb158a13792f2787f1c998e</Hash>
</Codenesium>*/