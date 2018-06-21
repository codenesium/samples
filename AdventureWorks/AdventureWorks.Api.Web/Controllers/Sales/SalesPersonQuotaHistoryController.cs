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
        [Route("api/salesPersonQuotaHistories")]
        [ApiVersion("1.0")]
        public class SalesPersonQuotaHistoryController : AbstractSalesPersonQuotaHistoryController
        {
                public SalesPersonQuotaHistoryController(
                        ApiSettings settings,
                        ILogger<SalesPersonQuotaHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesPersonQuotaHistoryService salesPersonQuotaHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesPersonQuotaHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f26682182be43b05961383e342c66176</Hash>
</Codenesium>*/