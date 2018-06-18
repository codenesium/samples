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
                        ILogger<INuGetPackageRepository> logger,
                        INuGetPackageRepository nuGetPackageRepository,
                        IApiNuGetPackageRequestModelValidator nuGetPackageModelValidator,
                        IBOLNuGetPackageMapper bolnuGetPackageMapper,
                        IDALNuGetPackageMapper dalnuGetPackageMapper

                        )
                        : base(logger,
                               nuGetPackageRepository,
                               nuGetPackageModelValidator,
                               bolnuGetPackageMapper,
                               dalnuGetPackageMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f1f424d899c03c6ccd6c74306813fc59</Hash>
</Codenesium>*/