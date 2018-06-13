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
        public class InterruptionService: AbstractInterruptionService, IInterruptionService
        {
                public InterruptionService(
                        ILogger<InterruptionRepository> logger,
                        IInterruptionRepository interruptionRepository,
                        IApiInterruptionRequestModelValidator interruptionModelValidator,
                        IBOLInterruptionMapper bolinterruptionMapper,
                        IDALInterruptionMapper dalinterruptionMapper

                        )
                        : base(logger,
                               interruptionRepository,
                               interruptionModelValidator,
                               bolinterruptionMapper,
                               dalinterruptionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>95eee1e6f62d18b6f0d8fd2bf0681bb4</Hash>
</Codenesium>*/