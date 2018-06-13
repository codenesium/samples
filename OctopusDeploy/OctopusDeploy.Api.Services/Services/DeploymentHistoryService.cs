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
                        ILogger<DeploymentHistoryRepository> logger,
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
    <Hash>1878f4960d22b44d4a806da4bd37e052</Hash>
</Codenesium>*/