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
        [Route("api/workerTaskLeases")]
        [ApiVersion("1.0")]
        public class WorkerTaskLeaseController : AbstractWorkerTaskLeaseController
        {
                public WorkerTaskLeaseController(
                        ApiSettings settings,
                        ILogger<WorkerTaskLeaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IWorkerTaskLeaseService workerTaskLeaseService,
                        IApiWorkerTaskLeaseModelMapper workerTaskLeaseModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               workerTaskLeaseService,
                               workerTaskLeaseModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7f43c5448937a079862de60c6d054196</Hash>
</Codenesium>*/