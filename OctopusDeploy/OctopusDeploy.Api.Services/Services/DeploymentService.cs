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
        public partial class DeploymentService : AbstractDeploymentService, IDeploymentService
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
    <Hash>2b116e9a2093aa21d27825dcc082f1f0</Hash>
</Codenesium>*/