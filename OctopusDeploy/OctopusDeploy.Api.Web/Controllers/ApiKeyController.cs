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
        [Route("api/apiKeys")]
        [ApiVersion("1.0")]
        public class ApiKeyController: AbstractApiKeyController
        {
                public ApiKeyController(
                        ApiSettings settings,
                        ILogger<ApiKeyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IApiKeyService apiKeyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               apiKeyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>46e8a398e47df3bdf29f3d60bc74d74d</Hash>
</Codenesium>*/