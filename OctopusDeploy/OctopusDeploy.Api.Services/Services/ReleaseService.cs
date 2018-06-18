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
                               dalreleaseMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>3d9b2c209e96784458e32185990b79f5</Hash>
</Codenesium>*/