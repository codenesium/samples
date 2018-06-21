using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/events")]
        [ApiVersion("1.0")]
        public class EventController : AbstractEventController
        {
                public EventController(
                        ApiSettings settings,
                        ILogger<EventController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventService eventService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               eventService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>203fe86a98e8ae7b8c89f28b4236c568</Hash>
</Codenesium>*/