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
        [Route("api/releases")]
        [ApiVersion("1.0")]
        public class ReleaseController: AbstractReleaseController
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
    <Hash>0dca18c1b2293232f5aa7a64bc9e99d0</Hash>
</Codenesium>*/