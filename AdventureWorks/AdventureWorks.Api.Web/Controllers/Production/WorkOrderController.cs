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
                        ServiceSettings settings,
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
    <Hash>05297a05e2de211e9e1ed284dbd02615</Hash>
</Codenesium>*/