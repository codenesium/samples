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
        [Route("api/salesOrderHeaders")]
        [ApiVersion("1.0")]
        public class SalesOrderHeaderController: AbstractSalesOrderHeaderController
        {
                public SalesOrderHeaderController(
                        ServiceSettings settings,
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
    <Hash>60d3f5a6c537ac0e5fecd6836893472c</Hash>
</Codenesium>*/