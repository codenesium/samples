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
        [Route("api/machinePolicies")]
        [ApiVersion("1.0")]
        public class MachinePolicyController : AbstractMachinePolicyController
        {
                public MachinePolicyController(
                        ApiSettings settings,
                        ILogger<MachinePolicyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IMachinePolicyService machinePolicyService,
                        IApiMachinePolicyModelMapper machinePolicyModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               machinePolicyService,
                               machinePolicyModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>366fbaf8c70f0df9799d4b8624925869</Hash>
</Codenesium>*/