using Codenesium.DataConversionExtensions.AspNetCore;
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
        public class LifecycleService : AbstractLifecycleService, ILifecycleService
        {
                public LifecycleService(
                        ILogger<ILifecycleRepository> logger,
                        ILifecycleRepository lifecycleRepository,
                        IApiLifecycleRequestModelValidator lifecycleModelValidator,
                        IBOLLifecycleMapper bollifecycleMapper,
                        IDALLifecycleMapper dallifecycleMapper
                        )
                        : base(logger,
                               lifecycleRepository,
                               lifecycleModelValidator,
                               bollifecycleMapper,
                               dallifecycleMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>45cc86564e93b2bf47d3105ca651903c</Hash>
</Codenesium>*/