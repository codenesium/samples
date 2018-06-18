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
        [Route("api/workOrders")]
        [ApiVersion("1.0")]
        public class WorkOrderController: AbstractWorkOrderController
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
    <Hash>76b11ed3d6859ffcda1a40b78d73210c</Hash>
</Codenesium>*/