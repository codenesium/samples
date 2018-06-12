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
        [Route("api/machinePolicies")]
        [ApiVersion("1.0")]
        public class MachinePolicyController: AbstractMachinePolicyController
        {
                public MachinePolicyController(
                        ServiceSettings settings,
                        ILogger<MachinePolicyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachinePolicyService machinePolicyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machinePolicyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>00f1f8c5eee3e282a6b1141452c7d4f8</Hash>
</Codenesium>*/