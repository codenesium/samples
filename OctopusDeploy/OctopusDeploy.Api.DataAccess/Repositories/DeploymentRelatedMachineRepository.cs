using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class DeploymentRelatedMachineRepository : AbstractDeploymentRelatedMachineRepository, IDeploymentRelatedMachineRepository
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
    <Hash>5be090410756387a2199730f2a7d1bbd</Hash>
</Codenesium>*/