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
                        ServiceSettings settings,
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
    <Hash>cbff3ad15ff8bed2daee4ea2ee113072</Hash>
</Codenesium>*/