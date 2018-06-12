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
                        ServiceSettings settings,
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
    <Hash>6bbc4f825d5ab96c17d99af9016addf3</Hash>
</Codenesium>*/