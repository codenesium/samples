using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class PostsRepository : AbstractPostsRepository, IPostsRepository
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
    <Hash>2a582fe1c2e87ca1fd3d28b46a4218ac</Hash>
</Codenesium>*/