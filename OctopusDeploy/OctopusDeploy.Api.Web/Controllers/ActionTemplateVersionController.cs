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
        [Route("api/actionTemplateVersions")]
        [ApiVersion("1.0")]
        public class ActionTemplateVersionController: AbstractActionTemplateVersionController
        {
                public ActionTemplateVersionController(
                        ServiceSettings settings,
                        ILogger<ActionTemplateVersionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IActionTemplateVersionService actionTemplateVersionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               actionTemplateVersionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3b05b58c884087f61f9d200fe1ef7425</Hash>
</Codenesium>*/