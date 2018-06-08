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
                        IDALIllustrationMapper dalillustrationMapper)
                        : base(logger,
                               illustrationRepository,
                               illustrationModelValidator,
                               bolillustrationMapper,
                               dalillustrationMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>1735eb4deef9890879d2ab019c8037bb</Hash>
</Codenesium>*/