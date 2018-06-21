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
        [Route("api/projectTriggers")]
        [ApiVersion("1.0")]
        public class ProjectTriggerController : AbstractProjectTriggerController
        {
                public ProjectTriggerController(
                        ApiSettings settings,
                        ILogger<ProjectTriggerController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectTriggerService projectTriggerService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               projectTriggerService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7cbd31b3c4768156a68c6f0e297abd22</Hash>
</Codenesium>*/