using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ReleaseRepository : AbstractReleaseRepository, IReleaseRepository
        {
                public ReleaseRepository(
                        ILogger<ReleaseRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>f1a61c729d2b8f6cb91d490601b4aa68</Hash>
</Codenesium>*/