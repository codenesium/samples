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
        [ApiController]
        [ApiVersion("1.0")]
        public class EventController : AbstractEventController
        {
                public EventController(
                        ApiSettings settings,
                        ILogger<EventController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEventService eventService,
                        IApiEventModelMapper eventModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               eventService,
                               eventModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e814595ac583a06f58af3a3e5f45b09e</Hash>
</Codenesium>*/