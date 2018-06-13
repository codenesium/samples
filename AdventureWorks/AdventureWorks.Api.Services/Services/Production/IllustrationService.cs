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
        public class IllustrationService: AbstractIllustrationService, IIllustrationService
        {
                public IllustrationService(
                        ILogger<IllustrationRepository> logger,
                        IIllustrationRepository illustrationRepository,
                        IApiIllustrationRequestModelValidator illustrationModelValidator,
                        IBOLIllustrationMapper bolillustrationMapper,
                        IDALIllustrationMapper dalillustrationMapper
                        ,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper

                        )
                        : base(logger,
                               illustrationRepository,
                               illustrationModelValidator,
                               bolillustrationMapper,
                               dalillustrationMapper
                               ,
                               bolProductModelIllustrationMapper,
                               dalProductModelIllustrationMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f479ee396492ea8fba9a860f9b3d7597</Hash>
</Codenesium>*/