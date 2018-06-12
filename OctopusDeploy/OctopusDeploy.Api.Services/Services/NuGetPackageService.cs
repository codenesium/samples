using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class NuGetPackageService: AbstractNuGetPackageService, INuGetPackageService
        {
                public NuGetPackageService(
                        ILogger<NuGetPackageRepository> logger,
                        INuGetPackageRepository nuGetPackageRepository,
                        IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator,
                        IBOLNuGetPackageMapper bolnuGetPackageMapper,
                        IDALNuGetPackageMapper dalnuGetPackageMapper)
                        : base(logger,
                               nuGetPackageRepository,
                               nuGetPackageModelValidator,
                               bolnuGetPackageMapper,
                               dalnuGetPackageMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6436a8a04490cc7f8016b1738eaa2aeb</Hash>
</Codenesium>*/