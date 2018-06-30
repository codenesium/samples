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
        public partial class LifecycleService : AbstractLifecycleService, ILifecycleService
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
    <Hash>5a4e90fe10eca7ead2c778d85a676000</Hash>
</Codenesium>*/