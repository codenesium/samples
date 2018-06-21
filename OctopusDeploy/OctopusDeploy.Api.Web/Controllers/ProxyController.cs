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
        [Route("api/proxies")]
        [ApiVersion("1.0")]
        public class ProxyController : AbstractProxyController
        {
                public ProxyController(
                        ApiSettings settings,
                        ILogger<ProxyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProxyService proxyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               proxyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2716cacce5a2e58ae98c37f6ac62c7f8</Hash>
</Codenesium>*/