using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class NuGetPackageRepository: AbstractNuGetPackageRepository, INuGetPackageRepository
        {
                public NuGetPackageRepository(
                        ILogger<NuGetPackageRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>9e2b8cf8d4608807e669c88b45fb7fad</Hash>
</Codenesium>*/