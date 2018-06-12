using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/deploymentHistories")]
        [ApiVersion("1.0")]
        public class DeploymentHistoryController: AbstractDeploymentHistoryController
        {
                public DeploymentHistoryController(
                        ServiceSettings settings,
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
    <Hash>ee39a6fd1a33725f20aec345f132b105</Hash>
</Codenesium>*/