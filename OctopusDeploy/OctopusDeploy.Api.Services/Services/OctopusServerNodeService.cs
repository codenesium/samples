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
        public class OctopusServerNodeService: AbstractOctopusServerNodeService, IOctopusServerNodeService
        {
                public OctopusServerNodeService(
                        ILogger<OctopusServerNodeRepository> logger,
                        IOctopusServerNodeRepository octopusServerNodeRepository,
                        IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator,
                        IBOLOctopusServerNodeMapper boloctopusServerNodeMapper,
                        IDALOctopusServerNodeMapper daloctopusServerNodeMapper

                        )
                        : base(logger,
                               octopusServerNodeRepository,
                               octopusServerNodeModelValidator,
                               boloctopusServerNodeMapper,
                               daloctopusServerNodeMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>00337a40d27b1f1b4858a79f67a8a050</Hash>
</Codenesium>*/