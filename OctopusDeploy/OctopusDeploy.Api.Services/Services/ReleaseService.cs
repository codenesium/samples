using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class ReleaseService: AbstractReleaseService, IReleaseService
        {
                public ReleaseService(
                        ILogger<ReleaseRepository> logger,
                        IReleaseRepository releaseRepository,
                        IApiReleaseRequestModelValidator releaseModelValidator,
                        IBOLReleaseMapper bolreleaseMapper,
                        IDALReleaseMapper dalreleaseMapper)
                        : base(logger,
                               releaseRepository,
                               releaseModelValidator,
                               bolreleaseMapper,
                               dalreleaseMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ccba7ddb6cd3825ea9f9e2ff90fdc88a</Hash>
</Codenesium>*/