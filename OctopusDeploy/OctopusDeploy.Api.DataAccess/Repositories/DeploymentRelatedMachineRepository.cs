using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentRelatedMachineRepository: AbstractDeploymentRelatedMachineRepository, IDeploymentRelatedMachineRepository
        {
                public DeploymentRelatedMachineRepository(
                        ILogger<DeploymentRelatedMachineRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>27296f313985c563826a618229573eb6</Hash>
</Codenesium>*/