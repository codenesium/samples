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
        [Route("api/actionTemplates")]
        [ApiVersion("1.0")]
        public class ActionTemplateController: AbstractActionTemplateController
        {
                public ActionTemplateController(
                        ServiceSettings settings,
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
    <Hash>073b9d1699a2732138ec572e94d0dc8e</Hash>
</Codenesium>*/