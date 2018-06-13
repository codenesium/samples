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
                        IDALLifecycleMapper dallifecycleMapper

                        )
                        : base(logger,
                               lifecycleRepository,
                               lifecycleModelValidator,
                               bollifecycleMapper,
                               dallifecycleMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>3641314acdb424f86ba5ed6a5a8b5bc5</Hash>
</Codenesium>*/