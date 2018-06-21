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
        [Route("api/pipelineStepNotes")]
        [ApiVersion("1.0")]
        public class PipelineStepNoteController : AbstractPipelineStepNoteController
        {
                public PipelineStepNoteController(
                        ApiSettings settings,
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
    <Hash>5bd9bd7957983e71a72910162da56b8d</Hash>
</Codenesium>*/