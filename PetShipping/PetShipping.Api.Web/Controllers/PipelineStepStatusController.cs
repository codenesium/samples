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
        [Route("api/pipelineStepStatus")]
        [ApiVersion("1.0")]
        public class PipelineStepStatusController: AbstractPipelineStepStatusController
        {
                public PipelineStepStatusController(
                        ServiceSettings settings,
                        ILogger<PipelineStepStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepStatusService pipelineStepStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9d06df204b92c6e741e884a0c8ad49e0</Hash>
</Codenesium>*/