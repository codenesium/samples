using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class MachinePolicyRepository : AbstractMachinePolicyRepository, IMachinePolicyRepository
        {
                public MachinePolicyRepository(
                        ILogger<MachinePolicyRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>216d81be921854fedef64ced2f2fbc59</Hash>
</Codenesium>*/