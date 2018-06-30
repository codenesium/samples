using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/tickets")]
        [ApiVersion("1.0")]
        public class TicketController : AbstractTicketController
        {
                public TicketController(
                        ApiSettings settings,
                        ILogger<TicketController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITicketService ticketService,
                        IApiTicketModelMapper ticketModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               ticketService,
                               ticketModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>37deb1f33bfc388d216b91c8d492c914</Hash>
</Codenesium>*/