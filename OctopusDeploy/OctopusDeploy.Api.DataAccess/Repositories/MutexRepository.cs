using Codenesium.DataConversionExtensions;
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
    <Hash>257775616e0027b75f71e184db1c63fe</Hash>
</Codenesium>*/