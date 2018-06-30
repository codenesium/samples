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
                        IOctopusServerNodeService octopusServerNodeService,
                        IApiOctopusServerNodeModelMapper octopusServerNodeModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               octopusServerNodeService,
                               octopusServerNodeModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5a5f0e44d756890be7f2214fa360bd05</Hash>
</Codenesium>*/