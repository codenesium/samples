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
        [Route("api/workOrderRoutings")]
        [ApiVersion("1.0")]
        public class WorkOrderRoutingController: AbstractWorkOrderRoutingController
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
    <Hash>04db38ed4b8167018fc3b0f865e83eeb</Hash>
</Codenesium>*/