using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class InterruptionRepository : AbstractInterruptionRepository, IInterruptionRepository
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
    <Hash>3b53b9e98f4a2268020ffbdbc36d195c</Hash>
</Codenesium>*/