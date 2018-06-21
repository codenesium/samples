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
    <Hash>fd1341cb8536899c49f46a8cd54fd723</Hash>
</Codenesium>*/