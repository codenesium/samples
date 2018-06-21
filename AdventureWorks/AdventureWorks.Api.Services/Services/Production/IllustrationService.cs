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
    <Hash>1b2a85d28926a8e800894fe8cf19c17d</Hash>
</Codenesium>*/