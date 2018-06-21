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
        [Route("api/pipelines")]
        [ApiVersion("1.0")]
        public class PipelineController : AbstractPipelineController
        {
                public PipelineController(
                        ApiSettings settings,
                        ILogger<PipelineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IPipelineService pipelineService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               pipelineService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1be90b0e25ec10e5d1d79622040dc547</Hash>
</Codenesium>*/