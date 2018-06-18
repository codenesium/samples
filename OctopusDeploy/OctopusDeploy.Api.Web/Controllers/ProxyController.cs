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
        [Route("api/proxies")]
        [ApiVersion("1.0")]
        public class ProxyController: AbstractProxyController
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
    <Hash>bf1a6f5de8c30580dfd185e11ca80d6e</Hash>
</Codenesium>*/