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
        [Route("api/deploymentEnvironments")]
        [ApiVersion("1.0")]
        public class DeploymentEnvironmentController: AbstractDeploymentEnvironmentController
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
    <Hash>19e9216f753b1abee539b63c180c7efd</Hash>
</Codenesium>*/