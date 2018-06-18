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
        public class DeploymentEnvironmentService: AbstractDeploymentEnvironmentService, IDeploymentEnvironmentService
        {
                public DeploymentEnvironmentService(
                        ILogger<IDeploymentEnvironmentRepository> logger,
                        IDeploymentEnvironmentRepository deploymentEnvironmentRepository,
                        IApiDeploymentEnvironmentRequestModelValidator deploymentEnvironmentModelValidator,
                        IBOLDeploymentEnvironmentMapper boldeploymentEnvironmentMapper,
                        IDALDeploymentEnvironmentMapper daldeploymentEnvironmentMapper

                        )
                        : base(logger,
                               deploymentEnvironmentRepository,
                               deploymentEnvironmentModelValidator,
                               boldeploymentEnvironmentMapper,
                               daldeploymentEnvironmentMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>aa100f6208c7fcb27d6d89f00b81a171</Hash>
</Codenesium>*/