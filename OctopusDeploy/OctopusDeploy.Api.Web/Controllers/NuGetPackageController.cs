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
                        INuGetPackageService nuGetPackageService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               nuGetPackageService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>98f0bc6df53c5a4d4c02e9bd8889435b</Hash>
</Codenesium>*/