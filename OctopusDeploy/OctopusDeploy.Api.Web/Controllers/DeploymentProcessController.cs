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
                        ServiceSettings settings,
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
    <Hash>775cf9cbbc463b553486366a9d4fabbc</Hash>
</Codenesium>*/