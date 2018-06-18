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
                               dalinterruptionMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>cf1a62b85077d869ef04a565fc13f5e5</Hash>
</Codenesium>*/