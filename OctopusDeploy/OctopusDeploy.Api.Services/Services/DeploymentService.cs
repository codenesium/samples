using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>d58150d74ce8bed38d2ef7bc22891ac6</Hash>
</Codenesium>*/