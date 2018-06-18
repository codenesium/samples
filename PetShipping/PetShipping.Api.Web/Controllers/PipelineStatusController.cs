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
        [Route("api/pipelineStatus")]
        [ApiVersion("1.0")]
        public class PipelineStatusController: AbstractPipelineStatusController
        {
                public PipelineStatusController(
                        ApiSettings settings,
                        ILogger<PipelineStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStatusService pipelineStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f649d42f4efbaf6c3eb5774a6eecc09b</Hash>
</Codenesium>*/