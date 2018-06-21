using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
        [Route("api/pipelineSteps")]
        [ApiVersion("1.0")]
        public class PipelineStepController : AbstractPipelineStepController
        {
                public PipelineStepController(
                        ApiSettings settings,
                        ILogger<PipelineStepController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepService pipelineStepService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a1c230504d05c325c634214716d39815</Hash>
</Codenesium>*/