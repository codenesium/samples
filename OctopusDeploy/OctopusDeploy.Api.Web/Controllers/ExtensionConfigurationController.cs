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
        [Route("api/extensionConfigurations")]
        [ApiVersion("1.0")]
        public class ExtensionConfigurationController: AbstractExtensionConfigurationController
        {
                public ExtensionConfigurationController(
                        ServiceSettings settings,
                        ILogger<ExtensionConfigurationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IExtensionConfigurationService extensionConfigurationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               extensionConfigurationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>07aaae6cbc2215df2d71e6d1f5aa33ef</Hash>
</Codenesium>*/