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
        [Route("api/actionTemplateVersions")]
        [ApiVersion("1.0")]
        public class ActionTemplateVersionController : AbstractActionTemplateVersionController
        {
                public ActionTemplateVersionController(
                        ApiSettings settings,
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
    <Hash>5d55a5e48125786216342308415a3526</Hash>
</Codenesium>*/