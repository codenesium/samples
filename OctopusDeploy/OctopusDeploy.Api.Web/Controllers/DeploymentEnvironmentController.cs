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
        [Route("api/deploymentEnvironments")]
        [ApiVersion("1.0")]
        public class DeploymentEnvironmentController : AbstractDeploymentEnvironmentController
        {
                public DeploymentEnvironmentController(
                        ApiSettings settings,
                        ILogger<DeploymentEnvironmentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentEnvironmentService deploymentEnvironmentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentEnvironmentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c00c6010d00e886b68a0cc38eaef4c33</Hash>
</Codenesium>*/