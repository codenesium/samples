using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class MutexRepository : AbstractMutexRepository, IMutexRepository
        {
                public MutexRepository(
                        ILogger<MutexRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6cb0212c7c6d3bb6b49b092dc03a796c</Hash>
</Codenesium>*/