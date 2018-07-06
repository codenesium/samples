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
        [Route("api/pipelineStepDestinations")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PipelineStepDestinationController : AbstractPipelineStepDestinationController
        {
                public PipelineStepDestinationController(
                        ApiSettings settings,
                        ILogger<PipelineStepDestinationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepDestinationService pipelineStepDestinationService,
                        IApiPipelineStepDestinationModelMapper pipelineStepDestinationModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepDestinationService,
                               pipelineStepDestinationModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>80c52f4ce0e911bfc97d00f8b7c3d6a3</Hash>
</Codenesium>*/