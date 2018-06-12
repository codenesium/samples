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
        [Route("api/projects")]
        [ApiVersion("1.0")]
        public class ProjectController: AbstractProjectController
        {
                public ProjectController(
                        ServiceSettings settings,
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
    <Hash>0f6c34edb0029272e98fe2a0c2e216f1</Hash>
</Codenesium>*/