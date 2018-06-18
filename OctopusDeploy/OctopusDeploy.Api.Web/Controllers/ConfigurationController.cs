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
        [Route("api/configurations")]
        [ApiVersion("1.0")]
        public class ConfigurationController: AbstractConfigurationController
        {
                public ConfigurationController(
                        ApiSettings settings,
                        ILogger<ConfigurationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IConfigurationService configurationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               configurationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b49dc295880fcd4b46e730b03bf7db6d</Hash>
</Codenesium>*/