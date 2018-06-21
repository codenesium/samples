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
        public class DeploymentRelatedMachineService : AbstractDeploymentRelatedMachineService, IDeploymentRelatedMachineService
        {
                public DeploymentRelatedMachineService(
                        ILogger<IDeploymentRelatedMachineRepository> logger,
                        IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
                        IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
                        IBOLDeploymentRelatedMachineMapper boldeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper daldeploymentRelatedMachineMapper
                        )
                        : base(logger,
                               deploymentRelatedMachineRepository,
                               deploymentRelatedMachineModelValidator,
                               boldeploymentRelatedMachineMapper,
                               daldeploymentRelatedMachineMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>38a119436330df0fc713a93ea22cfe43</Hash>
</Codenesium>*/