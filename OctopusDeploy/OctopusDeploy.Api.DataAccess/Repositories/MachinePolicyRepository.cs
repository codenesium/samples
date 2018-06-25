using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class MachinePolicyRepository : AbstractMachinePolicyRepository, IMachinePolicyRepository
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
    <Hash>8958abf2784821fd49c68ce0bc247a17</Hash>
</Codenesium>*/