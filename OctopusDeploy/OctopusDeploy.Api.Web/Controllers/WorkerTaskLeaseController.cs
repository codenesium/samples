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
        [Route("api/workerTaskLeases")]
        [ApiVersion("1.0")]
        public class WorkerTaskLeaseController: AbstractWorkerTaskLeaseController
        {
                public WorkerTaskLeaseController(
                        ApiSettings settings,
                        ILogger<WorkerTaskLeaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerTaskLeaseService workerTaskLeaseService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workerTaskLeaseService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>26536f84e7e863c61ced01c0aa4e52ea</Hash>
</Codenesium>*/