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
                        ServiceSettings settings,
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
    <Hash>dbe4ef440fc360f8cdc51c7d62c7fc56</Hash>
</Codenesium>*/