using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>2f0659c7d6e4ada3309c543278520cbe</Hash>
</Codenesium>*/