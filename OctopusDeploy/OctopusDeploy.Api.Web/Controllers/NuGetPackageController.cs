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
        [Route("api/nuGetPackages")]
        [ApiVersion("1.0")]
        public class NuGetPackageController : AbstractNuGetPackageController
        {
                public NuGetPackageController(
                        ApiSettings settings,
                        ILogger<NuGetPackageController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        INuGetPackageService nuGetPackageService,
                        IApiNuGetPackageModelMapper nuGetPackageModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               nuGetPackageService,
                               nuGetPackageModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>924e8057201608d487f3452795b81458</Hash>
</Codenesium>*/