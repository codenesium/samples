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
        [Route("api/transactions")]
        [ApiVersion("1.0")]
        public class TransactionController : AbstractTransactionController
        {
                public TransactionController(
                        ApiSettings settings,
                        ILogger<TransactionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionService transactionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               transactionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2889c1adb83e0117b6d7c9d52fd45d11</Hash>
</Codenesium>*/