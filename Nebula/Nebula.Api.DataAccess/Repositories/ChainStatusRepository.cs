using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace NebulaNS.Api.DataAccess
{
        public class ChainStatusRepository : AbstractChainStatusRepository, IChainStatusRepository
        {
                public ChainStatusRepository(
                        ILogger<ChainStatusRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e119acd758bf5328067db7ccec9983ee</Hash>
</Codenesium>*/