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
        public class IllustrationService : AbstractIllustrationService, IIllustrationService
        {
                public IllustrationService(
                        ILogger<IIllustrationRepository> logger,
                        IIllustrationRepository illustrationRepository,
                        IApiIllustrationRequestModelValidator illustrationModelValidator,
                        IBOLIllustrationMapper bolillustrationMapper,
                        IDALIllustrationMapper dalillustrationMapper,
                        IBOLProductModelIllustrationMapper bolProductModelIllustrationMapper,
                        IDALProductModelIllustrationMapper dalProductModelIllustrationMapper
                        )
                        : base(logger,
                               illustrationRepository,
                               illustrationModelValidator,
                               bolillustrationMapper,
                               dalillustrationMapper,
                               bolProductModelIllustrationMapper,
                               dalProductModelIllustrationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>96e55c6439ff7be40ee730e70e1f78c8</Hash>
</Codenesium>*/