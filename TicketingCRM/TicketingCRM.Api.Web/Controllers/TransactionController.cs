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
        [Route("api/transactions")]
        [ApiVersion("1.0")]
        public class TransactionController: AbstractTransactionController
        {
                public TransactionController(
                        ServiceSettings settings,
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
    <Hash>4251d3c114ff7f614b3c52db8e3b6118</Hash>
</Codenesium>*/