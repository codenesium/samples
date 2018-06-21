using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/deploymentHistories")]
        [ApiVersion("1.0")]
        public class DeploymentHistoryController : AbstractDeploymentHistoryController
        {
                public DeploymentHistoryController(
                        ApiSettings settings,
                        ILogger<DeploymentHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentHistoryService deploymentHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4e85ec3eeb7e89737ec8ec0ade162dc3</Hash>
</Codenesium>*/