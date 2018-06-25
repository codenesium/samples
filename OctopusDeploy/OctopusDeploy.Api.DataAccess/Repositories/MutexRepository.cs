using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public partial class MutexRepository : AbstractMutexRepository, IMutexRepository
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
    <Hash>ed4253b8e992744dead8abbfdcb6e1be</Hash>
</Codenesium>*/