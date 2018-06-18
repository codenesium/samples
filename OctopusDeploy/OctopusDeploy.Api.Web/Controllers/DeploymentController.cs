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
        [Route("api/deployments")]
        [ApiVersion("1.0")]
        public class DeploymentController: AbstractDeploymentController
        {
                public DeploymentController(
                        ApiSettings settings,
                        ILogger<DeploymentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentService deploymentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>dec842468b71a5cc6530fa08e375deba</Hash>
</Codenesium>*/