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
                        IDeploymentService deploymentService,
                        IApiDeploymentModelMapper deploymentModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentService,
                               deploymentModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f4b21bdc553a45d83a30ce2c2090daf1</Hash>
</Codenesium>*/