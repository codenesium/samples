using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class AWBuildVersionRepository : AbstractAWBuildVersionRepository, IAWBuildVersionRepository
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
    <Hash>af01ab69c1172a4afa06aac59f2886eb</Hash>
</Codenesium>*/