using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentEnvironmentRepository : AbstractDeploymentEnvironmentRepository, IDeploymentEnvironmentRepository
        {
                public DeploymentEnvironmentRepository(
                        ILogger<DeploymentEnvironmentRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>edf82f06a4692a6f5270702eb0997966</Hash>
</Codenesium>*/