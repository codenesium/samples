using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class NuGetPackageRepository : AbstractNuGetPackageRepository, INuGetPackageRepository
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
    <Hash>fc1cf732e6c55bc1f7624b455660d94b</Hash>
</Codenesium>*/