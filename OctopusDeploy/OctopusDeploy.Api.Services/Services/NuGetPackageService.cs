using Codenesium.DataConversionExtensions;
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
    <Hash>c9933b3c7ab3ac90c8565fc693d03ebd</Hash>
</Codenesium>*/