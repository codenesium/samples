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
        public class InterruptionService : AbstractInterruptionService, IInterruptionService
        {
                public InterruptionService(
                        ILogger<IInterruptionRepository> logger,
                        IInterruptionRepository interruptionRepository,
                        IApiInterruptionRequestModelValidator interruptionModelValidator,
                        IBOLInterruptionMapper bolinterruptionMapper,
                        IDALInterruptionMapper dalinterruptionMapper
                        )
                        : base(logger,
                               interruptionRepository,
                               interruptionModelValidator,
                               bolinterruptionMapper,
                               dalinterruptionMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>4137ced23968afcce160b11e84b55b8c</Hash>
</Codenesium>*/