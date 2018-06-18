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
        public class DeploymentService: AbstractDeploymentService, IDeploymentService
        {
                public DeploymentService(
                        ILogger<IDeploymentRepository> logger,
                        IDeploymentRepository deploymentRepository,
                        IApiDeploymentRequestModelValidator deploymentModelValidator,
                        IBOLDeploymentMapper boldeploymentMapper,
                        IDALDeploymentMapper daldeploymentMapper
                        ,
                        IBOLDeploymentRelatedMachineMapper bolDeploymentRelatedMachineMapper,
                        IDALDeploymentRelatedMachineMapper dalDeploymentRelatedMachineMapper

                        )
                        : base(logger,
                               deploymentRepository,
                               deploymentModelValidator,
                               boldeploymentMapper,
                               daldeploymentMapper
                               ,
                               bolDeploymentRelatedMachineMapper,
                               dalDeploymentRelatedMachineMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>4671e183cfba646a98f86eba94f5a4b5</Hash>
</Codenesium>*/