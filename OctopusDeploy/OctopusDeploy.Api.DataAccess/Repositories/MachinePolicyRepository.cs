using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>1c6fa4b94500f8e20ed3048ff699dce4</Hash>
</Codenesium>*/