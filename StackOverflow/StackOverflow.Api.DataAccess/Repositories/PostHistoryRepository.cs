using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class PostHistoryRepository : AbstractPostHistoryRepository, IPostHistoryRepository
        {
                public PostHistoryRepository(
                        ILogger<PostHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>76995686e1246a263f56365991b211c1</Hash>
</Codenesium>*/