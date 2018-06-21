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
        [Route("api/configurations")]
        [ApiVersion("1.0")]
        public class ConfigurationController : AbstractConfigurationController
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
    <Hash>b8a12f18cbf3d4fd20273e3edf3ccdab</Hash>
</Codenesium>*/