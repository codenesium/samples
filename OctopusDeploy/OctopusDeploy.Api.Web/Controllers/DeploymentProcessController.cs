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
        [Route("api/deploymentProcesses")]
        [ApiVersion("1.0")]
        public class DeploymentProcessController: AbstractDeploymentProcessController
        {
                public DeploymentProcessController(
                        ApiSettings settings,
                        ILogger<DeploymentProcessController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentProcessService deploymentProcessService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentProcessService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>fca4d03ad21666adace5fd7967c0fc02</Hash>
</Codenesium>*/