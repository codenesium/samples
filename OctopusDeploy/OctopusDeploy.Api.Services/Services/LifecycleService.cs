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
        public class LifecycleService: AbstractLifecycleService, ILifecycleService
        {
                public LifecycleService(
                        ILogger<LifecycleRepository> logger,
                        ILifecycleRepository lifecycleRepository,
                        IApiLifecycleRequestModelValidator lifecycleModelValidator,
                        IBOLLifecycleMapper bollifecycleMapper,
                        IDALLifecycleMapper dallifecycleMapper)
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
    <Hash>3606e482d82723e7414e55844ce6fc50</Hash>
</Codenesium>*/