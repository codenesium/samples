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
        [Route("api/pipelineStepStepRequirements")]
        [ApiVersion("1.0")]
        public class PipelineStepStepRequirementController : AbstractPipelineStepStepRequirementController
        {
                public PipelineStepStepRequirementController(
                        ApiSettings settings,
                        ILogger<PipelineStepStepRequirementController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepStepRequirementService pipelineStepStepRequirementService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepStepRequirementService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f3c56356980292e49a4a2b99ed3933a7</Hash>
</Codenesium>*/