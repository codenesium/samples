using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/transactionHistories")]
        [ApiVersion("1.0")]
        public class TransactionHistoryController: AbstractTransactionHistoryController
        {
                public TransactionHistoryController(
                        ServiceSettings settings,
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
    <Hash>24709435f60add1fe4712a2d8d9cf62a</Hash>
</Codenesium>*/