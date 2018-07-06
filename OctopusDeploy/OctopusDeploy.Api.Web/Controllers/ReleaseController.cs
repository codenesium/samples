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
        [ApiController]
        [ApiVersion("1.0")]
        public class ReleaseController : AbstractReleaseController
        {
                public ReleaseController(
                        ApiSettings settings,
                        ILogger<ReleaseController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IReleaseService releaseService,
                        IApiReleaseModelMapper releaseModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               releaseService,
                               releaseModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>39c19a9bc0af81218813d2408799af55</Hash>
</Codenesium>*/