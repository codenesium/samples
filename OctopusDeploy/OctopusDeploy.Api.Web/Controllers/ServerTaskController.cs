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
        [Route("api/serverTasks")]
        [ApiVersion("1.0")]
        public class ServerTaskController: AbstractServerTaskController
        {
                public ServerTaskController(
                        ApiSettings settings,
                        ILogger<ServerTaskController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IServerTaskService serverTaskService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               serverTaskService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>eb2336385804c28b2efda17356fcba06</Hash>
</Codenesium>*/