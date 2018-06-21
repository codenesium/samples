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
        [Route("api/ticketStatus")]
        [ApiVersion("1.0")]
        public class TicketStatusController : AbstractTicketStatusController
        {
                public TicketStatusController(
                        ApiSettings settings,
                        ILogger<TicketStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITicketStatusService ticketStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               ticketStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>bfbd9832fe3efe452a1dc73022a13164</Hash>
</Codenesium>*/