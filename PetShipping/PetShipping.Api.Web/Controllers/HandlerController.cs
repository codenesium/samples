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
        [Route("api/handlers")]
        [ApiVersion("1.0")]
        public class HandlerController : AbstractHandlerController
        {
                public HandlerController(
                        ApiSettings settings,
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
    <Hash>6813dc6bf7cf8e8356aacda7c1b6f312</Hash>
</Codenesium>*/