using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class ReleaseService : AbstractReleaseService, IReleaseService
        {
                public ReleaseService(
                        ILogger<IReleaseRepository> logger,
                        IReleaseRepository releaseRepository,
                        IApiReleaseRequestModelValidator releaseModelValidator,
                        IBOLReleaseMapper bolreleaseMapper,
                        IDALReleaseMapper dalreleaseMapper
                        )
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
    <Hash>06521225e2754a2e8e850185b7f93988</Hash>
</Codenesium>*/