using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.Services;

namespace OctopusDeployNS.Api.Web
{
        [Route("api/workerPools")]
        [ApiVersion("1.0")]
        public class WorkerPoolController: AbstractWorkerPoolController
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
    <Hash>3dd6221e83d32f2cfa29a44e1c41e43b</Hash>
</Codenesium>*/