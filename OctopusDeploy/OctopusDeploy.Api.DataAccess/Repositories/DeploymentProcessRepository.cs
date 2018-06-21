using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentProcessRepository : AbstractDeploymentProcessRepository, IDeploymentProcessRepository
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
    <Hash>510e03e8576eb756578d29f9671c352b</Hash>
</Codenesium>*/