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
        [Route("api/pipelineStepNotes")]
        [ApiVersion("1.0")]
        public class PipelineStepNoteController: AbstractPipelineStepNoteController
        {
                public PipelineStepNoteController(
                        ServiceSettings settings,
                        ILogger<PipelineStepNoteController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepNoteService pipelineStepNoteService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepNoteService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c9f25e0f4d133f817a67ed30364016d7</Hash>
</Codenesium>*/