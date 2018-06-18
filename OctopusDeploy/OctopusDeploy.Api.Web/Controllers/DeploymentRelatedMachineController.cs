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
        [Route("api/deploymentRelatedMachines")]
        [ApiVersion("1.0")]
        public class DeploymentRelatedMachineController: AbstractDeploymentRelatedMachineController
        {
                public DeploymentRelatedMachineController(
                        ApiSettings settings,
                        ILogger<DeploymentRelatedMachineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDeploymentRelatedMachineService deploymentRelatedMachineService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               deploymentRelatedMachineService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d39dedcf6534983c4f25cbf5c9148e84</Hash>
</Codenesium>*/