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
        [ApiController]
        [ApiVersion("1.0")]
        public class SalesPersonQuotaHistoryController : AbstractSalesPersonQuotaHistoryController
        {
                public SalesPersonQuotaHistoryController(
                        ApiSettings settings,
                        ILogger<SalesPersonQuotaHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesPersonQuotaHistoryService salesPersonQuotaHistoryService,
                        IApiSalesPersonQuotaHistoryModelMapper salesPersonQuotaHistoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesPersonQuotaHistoryService,
                               salesPersonQuotaHistoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0425b430d4f4204b8a67c3371d62d24a</Hash>
</Codenesium>*/