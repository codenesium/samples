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
        [ApiController]
        [ApiVersion("1.0")]
        public class WorkOrderController : AbstractWorkOrderController
        {
                public WorkOrderController(
                        ApiSettings settings,
                        ILogger<WorkOrderController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkOrderService workOrderService,
                        IApiWorkOrderModelMapper workOrderModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workOrderService,
                               workOrderModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e0aaf9ff9aa7f99a1a6cd509d5ea99bd</Hash>
</Codenesium>*/