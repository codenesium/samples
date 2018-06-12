using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class MachinePolicyRepository: AbstractMachinePolicyRepository, IMachinePolicyRepository
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
    <Hash>a0c9943f3a80d8d67be0d3782c316d0a</Hash>
</Codenesium>*/