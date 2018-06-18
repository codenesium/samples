using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
        [Route("api/pipelineSteps")]
        [ApiVersion("1.0")]
        public class PipelineStepController: AbstractPipelineStepController
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
    <Hash>5e3d0313d4d70d5e23dd66694a1cbb25</Hash>
</Codenesium>*/