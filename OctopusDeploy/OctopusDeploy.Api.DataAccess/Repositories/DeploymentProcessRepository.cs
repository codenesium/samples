using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class DeploymentProcessRepository : AbstractDeploymentProcessRepository, IDeploymentProcessRepository
        {
                public DeploymentProcessRepository(
                        ILogger<DeploymentProcessRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a9aa7d02f02ebfa79297abed4602861c</Hash>
</Codenesium>*/