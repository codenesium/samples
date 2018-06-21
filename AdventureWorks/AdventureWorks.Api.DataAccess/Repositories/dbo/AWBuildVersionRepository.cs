using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class AWBuildVersionRepository : AbstractAWBuildVersionRepository, IAWBuildVersionRepository
        {
                public AWBuildVersionRepository(
                        ILogger<AWBuildVersionRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>ec45952e7467e5692b4d07d279c49c74</Hash>
</Codenesium>*/