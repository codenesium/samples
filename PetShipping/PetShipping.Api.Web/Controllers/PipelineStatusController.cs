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
    <Hash>5d26fee7e60eaa4b175f2fd321fe1528</Hash>
</Codenesium>*/