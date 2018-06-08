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
        [Route("api/pipelineStepDestinations")]
        [ApiVersion("1.0")]
        public class PipelineStepDestinationController: AbstractPipelineStepDestinationController
        {
                public PipelineStepDestinationController(
                        ServiceSettings settings,
                        ILogger<PipelineStepDestinationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepDestinationService pipelineStepDestinationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepDestinationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a066b0ed0acdd07ac9406760a93c20aa</Hash>
</Codenesium>*/