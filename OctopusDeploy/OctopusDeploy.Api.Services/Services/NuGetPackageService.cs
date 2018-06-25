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
        public partial class NuGetPackageService : AbstractNuGetPackageService, INuGetPackageService
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
    <Hash>e19c2e3f1c56638ac1f3a2645ba96b2a</Hash>
</Codenesium>*/