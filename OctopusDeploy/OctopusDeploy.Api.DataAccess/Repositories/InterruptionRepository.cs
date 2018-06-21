using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class InterruptionRepository : AbstractInterruptionRepository, IInterruptionRepository
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
    <Hash>e0a5fec85c6766b37b94f50f41a1431e</Hash>
</Codenesium>*/