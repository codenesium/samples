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
    <Hash>4e98c74002ef84fdac3a5ae314e36b06</Hash>
</Codenesium>*/