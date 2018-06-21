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
        [Route("api/projects")]
        [ApiVersion("1.0")]
        public class ProjectController : AbstractProjectController
        {
                public ProjectController(
                        ApiSettings settings,
                        ILogger<ProjectController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectService projectService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               projectService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>05080ac092b1e549366456177b292aa9</Hash>
</Codenesium>*/