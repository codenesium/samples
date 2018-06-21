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
        [Route("api/actionTemplates")]
        [ApiVersion("1.0")]
        public class ActionTemplateController : AbstractActionTemplateController
        {
                public ActionTemplateController(
                        ApiSettings settings,
                        ILogger<ActionTemplateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IActionTemplateService actionTemplateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               actionTemplateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e9fd4cf5f9d4b566df642f3fbe03d488</Hash>
</Codenesium>*/