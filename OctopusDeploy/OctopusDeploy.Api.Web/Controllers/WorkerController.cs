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
        [Route("api/workers")]
        [ApiVersion("1.0")]
        public class WorkerController: AbstractWorkerController
        {
                public WorkerController(
                        ServiceSettings settings,
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
    <Hash>d0eb1b6083e602853a3f1b2156522ec5</Hash>
</Codenesium>*/