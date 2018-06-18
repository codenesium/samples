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
        [Route("api/salesOrderDetails")]
        [ApiVersion("1.0")]
        public class SalesOrderDetailController: AbstractSalesOrderDetailController
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
    <Hash>b7e89bd8cc5830231d10c0b42ed7b415</Hash>
</Codenesium>*/