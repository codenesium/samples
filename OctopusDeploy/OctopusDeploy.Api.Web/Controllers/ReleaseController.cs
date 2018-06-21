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
        [Route("api/releases")]
        [ApiVersion("1.0")]
        public class ReleaseController : AbstractReleaseController
        {
                public ReleaseController(
                        ApiSettings settings,
                        ILogger<ReleaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IReleaseService releaseService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               releaseService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7d024379f1178922357b01ca4b628c5e</Hash>
</Codenesium>*/