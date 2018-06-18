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
        public class DeploymentProcessService: AbstractDeploymentProcessService, IDeploymentProcessService
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
                               daldeploymentProcessMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>ce064da1e910674ea483806b0b00cde6</Hash>
</Codenesium>*/