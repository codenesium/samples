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
        public class OctopusServerNodeService : AbstractOctopusServerNodeService, IOctopusServerNodeService
        {
                public OctopusServerNodeService(
                        ILogger<IOctopusServerNodeRepository> logger,
                        IOctopusServerNodeRepository octopusServerNodeRepository,
                        IApiOctopusServerNodeRequestModelValidator octopusServerNodeModelValidator,
                        IBOLOctopusServerNodeMapper boloctopusServerNodeMapper,
                        IDALOctopusServerNodeMapper daloctopusServerNodeMapper
                        )
                        : base(logger,
                               octopusServerNodeRepository,
                               octopusServerNodeModelValidator,
                               boloctopusServerNodeMapper,
                               daloctopusServerNodeMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b099c090c1bffa9e3ca1348867a8726b</Hash>
</Codenesium>*/