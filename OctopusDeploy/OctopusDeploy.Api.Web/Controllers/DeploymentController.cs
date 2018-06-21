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
        [Route("api/deployments")]
        [ApiVersion("1.0")]
        public class DeploymentController : AbstractDeploymentController
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
    <Hash>bbd5fbabaaf2d50546c57c4214df7dac</Hash>
</Codenesium>*/