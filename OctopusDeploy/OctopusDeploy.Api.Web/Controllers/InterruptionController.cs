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
                        IInterruptionService interruptionService,
                        IApiInterruptionModelMapper interruptionModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               interruptionService,
                               interruptionModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1f79d2922761c73075554d4f0f15ad41</Hash>
</Codenesium>*/