using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class PostHistoryRepository : AbstractPostHistoryRepository, IPostHistoryRepository
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
    <Hash>f7c20f77668a168b3b2d7cef9a83b224</Hash>
</Codenesium>*/