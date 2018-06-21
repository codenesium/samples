using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/transactionHistories")]
        [ApiVersion("1.0")]
        public class TransactionHistoryController : AbstractTransactionHistoryController
        {
                public TransactionHistoryController(
                        ApiSettings settings,
                        ILogger<TransactionHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITransactionHistoryService transactionHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               transactionHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>21016544b64d122923b2ac00f2eeff3f</Hash>
</Codenesium>*/