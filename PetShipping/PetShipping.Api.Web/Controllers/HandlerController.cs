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
                        IHandlerService handlerService,
                        IApiHandlerModelMapper handlerModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               handlerService,
                               handlerModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f2c2e1d6282645de5d8fa64ea8903760</Hash>
</Codenesium>*/