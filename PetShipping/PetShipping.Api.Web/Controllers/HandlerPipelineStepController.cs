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
        [Route("api/handlerPipelineSteps")]
        [ApiVersion("1.0")]
        public class HandlerPipelineStepController: AbstractHandlerPipelineStepController
        {
                public HandlerPipelineStepController(
                        ApiSettings settings,
                        ILogger<HandlerPipelineStepController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IHandlerPipelineStepService handlerPipelineStepService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               handlerPipelineStepService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ef424e48c198847c77bb490ea3c4d4e1</Hash>
</Codenesium>*/