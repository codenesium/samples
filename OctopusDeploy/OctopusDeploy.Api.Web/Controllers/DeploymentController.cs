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
                        ServiceSettings settings,
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
    <Hash>89dad0331372eea8a4f6ef13e98f3baa</Hash>
</Codenesium>*/