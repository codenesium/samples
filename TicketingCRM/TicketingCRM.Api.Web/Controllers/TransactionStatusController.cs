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
        [Route("api/transactionStatus")]
        [ApiVersion("1.0")]
        public class TransactionStatusController : AbstractTransactionStatusController
        {
                public TransactionStatusController(
                        ApiSettings settings,
                        ILogger<TransactionStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionStatusService transactionStatusService,
                        IApiTransactionStatusModelMapper transactionStatusModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               transactionStatusService,
                               transactionStatusModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1186baba86e66988d016ec821ac2f9a1</Hash>
</Codenesium>*/