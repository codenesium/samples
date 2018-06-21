using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>82e92deb2165a78c5d0502080ffc00c0</Hash>
</Codenesium>*/