using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public class PostLinksRepository : AbstractPostLinksRepository, IPostLinksRepository
        {
                public PostLinksRepository(
                        ILogger<PostLinksRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>12173f3c65e8c440ffa3c1b5f998adfc</Hash>
</Codenesium>*/