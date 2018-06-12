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
        [Route("api/nuGetPackages")]
        [ApiVersion("1.0")]
        public class NuGetPackageController: AbstractNuGetPackageController
        {
                public NuGetPackageController(
                        ServiceSettings settings,
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
    <Hash>997820a30f6a6b090c906552750fe5ae</Hash>
</Codenesium>*/