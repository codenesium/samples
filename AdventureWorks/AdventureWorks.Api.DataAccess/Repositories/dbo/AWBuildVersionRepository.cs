using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>9642743ee247ad3e14f5a078cd42ff75</Hash>
</Codenesium>*/