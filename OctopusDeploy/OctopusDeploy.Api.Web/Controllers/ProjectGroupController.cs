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
        [Route("api/projectGroups")]
        [ApiVersion("1.0")]
        public class ProjectGroupController : AbstractProjectGroupController
        {
                public ProjectGroupController(
                        ApiSettings settings,
                        ILogger<ProjectGroupController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProjectGroupService projectGroupService,
                        IApiProjectGroupModelMapper projectGroupModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               projectGroupService,
                               projectGroupModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>332a02445f27a8a8ff06557919a139b8</Hash>
</Codenesium>*/