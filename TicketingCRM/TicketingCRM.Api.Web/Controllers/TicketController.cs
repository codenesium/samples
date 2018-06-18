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
        [Route("api/tickets")]
        [ApiVersion("1.0")]
        public class TicketController: AbstractTicketController
        {
                public TicketController(
                        ApiSettings settings,
                        ILogger<TicketController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITicketService ticketService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               ticketService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7d0597e7eb93f1f510f4558e0a2b9c18</Hash>
</Codenesium>*/