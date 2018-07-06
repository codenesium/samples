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
        [ApiController]
        [ApiVersion("1.0")]
        public class PipelineStepNoteController : AbstractPipelineStepNoteController
        {
                public PipelineStepNoteController(
                        ApiSettings settings,
                        ILogger<PipelineStepNoteController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStepNoteService pipelineStepNoteService,
                        IApiPipelineStepNoteModelMapper pipelineStepNoteModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStepNoteService,
                               pipelineStepNoteModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>02398177983a57c061c759e6470a1f12</Hash>
</Codenesium>*/