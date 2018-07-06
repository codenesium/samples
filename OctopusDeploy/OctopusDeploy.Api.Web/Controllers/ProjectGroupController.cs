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
        [ApiController]
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
    <Hash>0e2acf687462ca658fa8d53100ee4675</Hash>
</Codenesium>*/