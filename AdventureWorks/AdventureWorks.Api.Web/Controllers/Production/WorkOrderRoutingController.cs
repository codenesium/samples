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
        [Route("api/workOrderRoutings")]
        [ApiVersion("1.0")]
        public class WorkOrderRoutingController : AbstractWorkOrderRoutingController
        {
                public WorkOrderRoutingController(
                        ApiSettings settings,
                        ILogger<WorkOrderRoutingController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkOrderRoutingService workOrderRoutingService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workOrderRoutingService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>dc50bdf7e4d4e324c04f71229398b41c</Hash>
</Codenesium>*/