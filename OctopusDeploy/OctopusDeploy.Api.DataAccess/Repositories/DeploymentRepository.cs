using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class DeploymentRepository : AbstractDeploymentRepository, IDeploymentRepository
        {
                public DeploymentRepository(
                        ILogger<DeploymentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a95f296115cd9612e61e3b2bf7cdc57e</Hash>
</Codenesium>*/