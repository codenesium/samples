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
        [Route("api/octopusServerNodes")]
        [ApiVersion("1.0")]
        public class OctopusServerNodeController : AbstractOctopusServerNodeController
        {
                public OctopusServerNodeController(
                        ApiSettings settings,
                        ILogger<OctopusServerNodeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOctopusServerNodeService octopusServerNodeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               octopusServerNodeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9a7965d5a007b90a49fc06865a386179</Hash>
</Codenesium>*/