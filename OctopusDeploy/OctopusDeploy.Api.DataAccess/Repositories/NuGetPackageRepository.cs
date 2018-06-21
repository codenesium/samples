using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>cac03f9e47954a23a0d200f11e91a34e</Hash>
</Codenesium>*/