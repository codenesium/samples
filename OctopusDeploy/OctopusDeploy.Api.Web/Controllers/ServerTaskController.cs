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
                        ServiceSettings settings,
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
    <Hash>06ca1225dfa926222a3b13ec85b06c7e</Hash>
</Codenesium>*/