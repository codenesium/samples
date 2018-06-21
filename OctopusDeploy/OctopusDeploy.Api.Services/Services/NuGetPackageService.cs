using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class NuGetPackageService : AbstractNuGetPackageService, INuGetPackageService
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
                               dalnuGetPackageMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>b833696375bf0393e21a219c11cfd546</Hash>
</Codenesium>*/