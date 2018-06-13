using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class DeploymentRelatedMachineService: AbstractDeploymentRelatedMachineService, IDeploymentRelatedMachineService
        {
                public DeploymentRelatedMachineService(
                        ILogger<DeploymentRelatedMachineRepository> logger,
                        IDeploymentRelatedMachineRepository deploymentRelatedMachineRepository,
                        IApiDeploymentRelatedMachineRequestModelValidator deploymentRelatedMachineModelValidator,
                        IBOLDeploymentRelatedMachineMapper boldeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper daldeploymentRelatedMachineMapper

                        )
                        : base(logger,
                               deploymentRelatedMachineRepository,
                               deploymentRelatedMachineModelValidator,
                               boldeploymentRelatedMachineMapper,
                               daldeploymentRelatedMachineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>dbabf2c19b995049632488af9b34ffa9</Hash>
</Codenesium>*/