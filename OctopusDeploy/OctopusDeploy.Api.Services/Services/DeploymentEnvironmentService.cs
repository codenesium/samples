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
        public class DeploymentEnvironmentService : AbstractDeploymentEnvironmentService, IDeploymentEnvironmentService
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
                               daldeploymentEnvironmentMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>8b2a01eca2883e71fed19f797d1c40a1</Hash>
</Codenesium>*/