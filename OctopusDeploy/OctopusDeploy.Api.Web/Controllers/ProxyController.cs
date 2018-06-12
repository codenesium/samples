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
                        ServiceSettings settings,
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
    <Hash>a564f52fabf7b167669a73bd1b02bfe1</Hash>
</Codenesium>*/