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
    <Hash>0b2694127d265756efc00f288dedde1c</Hash>
</Codenesium>*/