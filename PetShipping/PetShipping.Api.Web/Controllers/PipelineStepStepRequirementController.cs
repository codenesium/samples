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
        [Route("api/pipelineStepStepRequirements")]
        [ApiVersion("1.0")]
        public class PipelineStepStepRequirementController: AbstractPipelineStepStepRequirementController
        {
                public PipelineStepStepRequirementController(
                        ServiceSettings settings,
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
    <Hash>b829898418e158ad6d05b9ef11cbe558</Hash>
</Codenesium>*/