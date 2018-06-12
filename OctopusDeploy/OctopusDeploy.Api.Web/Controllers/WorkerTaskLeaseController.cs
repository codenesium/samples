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
                        ServiceSettings settings,
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
    <Hash>cade0213f86593ef48574a38fba89bc6</Hash>
</Codenesium>*/