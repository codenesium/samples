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
        [Route("api/salesOrderHeaderSalesReasons")]
        [ApiVersion("1.0")]
        public class SalesOrderHeaderSalesReasonController: AbstractSalesOrderHeaderSalesReasonController
        {
                public SalesOrderHeaderSalesReasonController(
                        ServiceSettings settings,
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
    <Hash>2cecbe4be29116efc78172857defa429</Hash>
</Codenesium>*/