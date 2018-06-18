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
        [Route("api/projectTriggers")]
        [ApiVersion("1.0")]
        public class ProjectTriggerController: AbstractProjectTriggerController
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
    <Hash>d1205f70ead71f572f8ffe0f3f5ca87a</Hash>
</Codenesium>*/