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
        [Route("api/pipelineStatus")]
        [ApiController]
        [ApiVersion("1.0")]
        public class PipelineStatusController : AbstractPipelineStatusController
        {
                public PipelineStatusController(
                        ApiSettings settings,
                        ILogger<PipelineStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineStatusService pipelineStatusService,
                        IApiPipelineStatusModelMapper pipelineStatusModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineStatusService,
                               pipelineStatusModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9eb0a01fd0aadb1c5ed8ab00c80f6a73</Hash>
</Codenesium>*/