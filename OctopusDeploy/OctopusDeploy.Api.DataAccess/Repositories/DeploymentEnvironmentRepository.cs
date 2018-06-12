using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentEnvironmentRepository: AbstractDeploymentEnvironmentRepository, IDeploymentEnvironmentRepository
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
    <Hash>59ba92f4111a5a775daf2662ef826379</Hash>
</Codenesium>*/