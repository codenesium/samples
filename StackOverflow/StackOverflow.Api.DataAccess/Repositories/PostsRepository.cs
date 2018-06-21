using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class PostsRepository : AbstractPostsRepository, IPostsRepository
        {
                public PostsRepository(
                        ILogger<PostsRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>14ec9856bf69ec534cc21881ab072e5b</Hash>
</Codenesium>*/