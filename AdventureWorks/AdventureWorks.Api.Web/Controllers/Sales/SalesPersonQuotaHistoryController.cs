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
        [Route("api/salesPersonQuotaHistories")]
        [ApiVersion("1.0")]
        public class SalesPersonQuotaHistoryController: AbstractSalesPersonQuotaHistoryController
        {
                public SalesPersonQuotaHistoryController(
                        ServiceSettings settings,
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
    <Hash>cbb42ab5520fcb1573085d438028ecf3</Hash>
</Codenesium>*/