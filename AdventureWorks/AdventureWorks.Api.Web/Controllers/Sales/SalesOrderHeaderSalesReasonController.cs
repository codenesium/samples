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
        [Route("api/salesOrderHeaderSalesReasons")]
        [ApiVersion("1.0")]
        public class SalesOrderHeaderSalesReasonController : AbstractSalesOrderHeaderSalesReasonController
        {
                public SalesOrderHeaderSalesReasonController(
                        ApiSettings settings,
                        ILogger<SalesOrderHeaderSalesReasonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderHeaderSalesReasonService salesOrderHeaderSalesReasonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesOrderHeaderSalesReasonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6d4d26ab29cab47ba7180461adacb07a</Hash>
</Codenesium>*/