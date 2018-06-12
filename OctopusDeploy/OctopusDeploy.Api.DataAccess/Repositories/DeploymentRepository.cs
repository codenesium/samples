using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentRepository: AbstractDeploymentRepository, IDeploymentRepository
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
    <Hash>fbc665e280d867c4dfc216c0c41a9c8f</Hash>
</Codenesium>*/