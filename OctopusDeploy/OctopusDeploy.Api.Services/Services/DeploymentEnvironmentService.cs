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
                        ILogger<DeploymentEnvironmentRepository> logger,
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
    <Hash>e49d0609227a71df34570fe09d0deda5</Hash>
</Codenesium>*/