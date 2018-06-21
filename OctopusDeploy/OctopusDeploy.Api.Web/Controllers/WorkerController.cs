using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/workers")]
        [ApiVersion("1.0")]
        public class WorkerController : AbstractWorkerController
        {
                public WorkerController(
                        ApiSettings settings,
                        ILogger<WorkerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerService workerService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workerService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f49029e1ab3fce80014edfef5f05276c</Hash>
</Codenesium>*/