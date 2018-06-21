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
        [Route("api/interruptions")]
        [ApiVersion("1.0")]
        public class InterruptionController : AbstractInterruptionController
        {
                public InterruptionController(
                        ApiSettings settings,
                        ILogger<InterruptionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IInterruptionService interruptionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               interruptionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1ab5837c256b7fed94f4a55783485d46</Hash>
</Codenesium>*/