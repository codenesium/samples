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
        [Route("api/workerPools")]
        [ApiVersion("1.0")]
        public class WorkerPoolController : AbstractWorkerPoolController
        {
                public WorkerPoolController(
                        ApiSettings settings,
                        ILogger<WorkerPoolController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerPoolService workerPoolService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workerPoolService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>48475c0f99dcf94a9fda4917f8a6e7b8</Hash>
</Codenesium>*/