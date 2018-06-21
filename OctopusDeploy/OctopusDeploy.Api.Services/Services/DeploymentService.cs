using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class DeploymentService : AbstractDeploymentService, IDeploymentService
        {
                public DeploymentService(
                        ILogger<IDeploymentRepository> logger,
                        IDeploymentRepository deploymentRepository,
                        IApiDeploymentRequestModelValidator deploymentModelValidator,
                        IBOLDeploymentMapper boldeploymentMapper,
                        IDALDeploymentMapper daldeploymentMapper,
                        IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper
                        )
                        : base(logger,
                               deploymentRepository,
                               deploymentModelValidator,
                               boldeploymentMapper,
                               daldeploymentMapper,
                               bolDeploymentRelatedMachineMapper,
                               dalDeploymentRelatedMachineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>831a8d6f087eb8cd3c8525de3b40b1e5</Hash>
</Codenesium>*/