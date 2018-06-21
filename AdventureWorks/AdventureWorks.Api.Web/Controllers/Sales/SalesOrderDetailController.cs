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
        [Route("api/salesOrderDetails")]
        [ApiVersion("1.0")]
        public class SalesOrderDetailController : AbstractSalesOrderDetailController
        {
                public SalesOrderDetailController(
                        ApiSettings settings,
                        ILogger<SalesOrderDetailController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderDetailService salesOrderDetailService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesOrderDetailService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a206e056be8e0c441066890903783277</Hash>
</Codenesium>*/