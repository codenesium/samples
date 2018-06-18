using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/events")]
        [ApiVersion("1.0")]
        public class EventController: AbstractEventController
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
    <Hash>37bcf9d10254feec6c1264892e0e79c1</Hash>
</Codenesium>*/