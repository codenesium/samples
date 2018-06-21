using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class FeedRepository : AbstractFeedRepository, IFeedRepository
        {
                public FeedRepository(
                        ILogger<FeedRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>44a514bd0cd6d3af4636b3d7c5ea287e</Hash>
</Codenesium>*/