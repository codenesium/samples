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
        [Route("api/octopusServerNodes")]
        [ApiVersion("1.0")]
        public class OctopusServerNodeController: AbstractOctopusServerNodeController
        {
                public OctopusServerNodeController(
                        ServiceSettings settings,
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
    <Hash>88455e6ca23970b51083d7d3030581d2</Hash>
</Codenesium>*/