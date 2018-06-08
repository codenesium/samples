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
        [Route("api/handlers")]
        [ApiVersion("1.0")]
        public class HandlerController: AbstractHandlerController
        {
                public HandlerController(
                        ServiceSettings settings,
                        ILogger<HandlerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IHandlerService handlerService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               handlerService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>900c87452ddb68216bbad25efd315669</Hash>
</Codenesium>*/