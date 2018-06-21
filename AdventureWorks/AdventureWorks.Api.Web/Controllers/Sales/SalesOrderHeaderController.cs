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
        [Route("api/salesOrderHeaders")]
        [ApiVersion("1.0")]
        public class SalesOrderHeaderController : AbstractSalesOrderHeaderController
        {
                public SalesOrderHeaderController(
                        ApiSettings settings,
                        ILogger<SalesOrderHeaderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesOrderHeaderService salesOrderHeaderService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesOrderHeaderService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1795cab4117a4f184c424e61e8d2facd</Hash>
</Codenesium>*/