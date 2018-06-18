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
        [Route("api/pipelines")]
        [ApiVersion("1.0")]
        public class PipelineController: AbstractPipelineController
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
    <Hash>f5b2d05b232685b1a254f87912641de2</Hash>
</Codenesium>*/