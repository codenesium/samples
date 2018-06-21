using Codenesium.DataConversionExtensions;
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
    <Hash>73b870c8c05129ece994df3f75313581</Hash>
</Codenesium>*/