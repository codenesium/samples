using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentProcessRepository: AbstractDeploymentProcessRepository, IDeploymentProcessRepository
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
    <Hash>569fcb90d298d6c4470876744cce764b</Hash>
</Codenesium>*/