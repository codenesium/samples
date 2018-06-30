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
                        ISalesOrderDetailService salesOrderDetailService,
                        IApiSalesOrderDetailModelMapper salesOrderDetailModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesOrderDetailService,
                               salesOrderDetailModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a5cd51a63754b079f5b12e6f1271029b</Hash>
</Codenesium>*/