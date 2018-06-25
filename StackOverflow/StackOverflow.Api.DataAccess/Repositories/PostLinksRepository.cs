using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace StackOverflowNS.Api.DataAccess
{
        public partial class PostLinksRepository : AbstractPostLinksRepository, IPostLinksRepository
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
    <Hash>47c4e833c7e393ea11d883dba7b0ec1a</Hash>
</Codenesium>*/