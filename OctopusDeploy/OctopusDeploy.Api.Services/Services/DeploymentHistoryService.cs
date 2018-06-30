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
        public partial class DeploymentHistoryService : AbstractDeploymentHistoryService, IDeploymentHistoryService
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
                               daldeploymentHistoryMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>063fbf2e31875ab35dfd657ce04d6139</Hash>
</Codenesium>*/