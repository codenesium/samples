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
    <Hash>ad6e9c8820e811ce21a00737b1b0b2ed</Hash>
</Codenesium>*/