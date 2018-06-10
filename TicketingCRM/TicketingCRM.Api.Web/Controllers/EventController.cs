using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/events")]
        [ApiVersion("1.0")]
        public class EventController: AbstractEventController
        {
                public EventController(
                        ServiceSettings settings,
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
    <Hash>950c8ec5687585aa08cae655cca7ef64</Hash>
</Codenesium>*/