using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class ReleaseRepository: AbstractReleaseRepository, IReleaseRepository
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
    <Hash>40beda39f1295465323ba2ae792e06ee</Hash>
</Codenesium>*/