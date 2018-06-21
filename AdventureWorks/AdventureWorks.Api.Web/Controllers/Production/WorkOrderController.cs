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
        [Route("api/workOrders")]
        [ApiVersion("1.0")]
        public class WorkOrderController : AbstractWorkOrderController
        {
                public WorkOrderController(
                        ApiSettings settings,
                        ILogger<WorkOrderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkOrderService workOrderService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workOrderService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>83ca5f5d73016e2eaa853de1671442ef</Hash>
</Codenesium>*/