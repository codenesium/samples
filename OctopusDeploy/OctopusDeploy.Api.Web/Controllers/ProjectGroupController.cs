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
        [Route("api/projectGroups")]
        [ApiVersion("1.0")]
        public class ProjectGroupController: AbstractProjectGroupController
        {
                public ProjectGroupController(
                        ApiSettings settings,
                        ILogger<ProjectGroupController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectGroupService projectGroupService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               projectGroupService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6c2848b0d2f5e4cc9dae4774d14d1d88</Hash>
</Codenesium>*/