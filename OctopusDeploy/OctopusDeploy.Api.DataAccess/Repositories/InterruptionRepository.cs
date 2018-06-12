using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class InterruptionRepository: AbstractInterruptionRepository, IInterruptionRepository
        {
                public InterruptionRepository(
                        ILogger<InterruptionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d07d17bbf561be46d048b58d67995d4f</Hash>
</Codenesium>*/