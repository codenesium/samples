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
                        IProxyService proxyService,
                        IApiProxyModelMapper proxyModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               proxyService,
                               proxyModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>4f6719aa983f481527cd7b8293020248</Hash>
</Codenesium>*/