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
        [Route("api/apiKeys")]
        [ApiVersion("1.0")]
        public class ApiKeyController : AbstractApiKeyController
        {
                public ApiKeyController(
                        ApiSettings settings,
                        ILogger<ApiKeyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IApiKeyService apiKeyService,
                        IApiApiKeyModelMapper apiKeyModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               apiKeyService,
                               apiKeyModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>55689721858ea68dea1ee239e0adf72e</Hash>
</Codenesium>*/