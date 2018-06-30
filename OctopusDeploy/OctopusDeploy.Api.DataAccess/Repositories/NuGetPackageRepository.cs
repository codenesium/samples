using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class NuGetPackageRepository : AbstractNuGetPackageRepository, INuGetPackageRepository
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
    <Hash>3b820c99796736c7906701dd386a1261</Hash>
</Codenesium>*/