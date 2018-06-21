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
        public class DeploymentProcessService : AbstractDeploymentProcessService, IDeploymentProcessService
        {
                public DeploymentProcessService(
                        ILogger<IDeploymentProcessRepository> logger,
                        IDeploymentProcessRepository deploymentProcessRepository,
                        IApiDeploymentProcessRequestModelValidator deploymentProcessModelValidator,
                        IBOLDeploymentProcessMapper boldeploymentProcessMapper,
                        IDALDeploymentProcessMapper daldeploymentProcessMapper
                        )
                        : base(logger,
                               deploymentProcessRepository,
                               deploymentProcessModelValidator,
                               boldeploymentProcessMapper,
                               daldeploymentProcessMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5c9351354b6b50f0d1b3255ec1ce7717</Hash>
</Codenesium>*/