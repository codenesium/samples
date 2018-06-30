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
        [Route("api/serverTasks")]
        [ApiVersion("1.0")]
        public class ServerTaskController : AbstractServerTaskController
        {
                public ServerTaskController(
                        ApiSettings settings,
                        ILogger<ServerTaskController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IServerTaskService serverTaskService,
                        IApiServerTaskModelMapper serverTaskModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               serverTaskService,
                               serverTaskModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9b9b1fbef77a8be5212ceaa13968a6f0</Hash>
</Codenesium>*/