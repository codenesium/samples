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
        public class DeploymentHistoryService: AbstractDeploymentHistoryService, IDeploymentHistoryService
        {
                public DeploymentHistoryService(
                        ILogger<IDeploymentHistoryRepository> logger,
                        IDeploymentHistoryRepository deploymentHistoryRepository,
                        IApiDeploymentHistoryRequestModelValidator deploymentHistoryModelValidator,
                        IBOLDeploymentHistoryMapper boldeploymentHistoryMapper,
                        IDALDeploymentHistoryMapper daldeploymentHistoryMapper

                        )
                        : base(logger,
                               deploymentHistoryRepository,
                               deploymentHistoryModelValidator,
                               boldeploymentHistoryMapper,
                               daldeploymentHistoryMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b5c5d49ea06c9ea958a3aee1f981601b</Hash>
</Codenesium>*/