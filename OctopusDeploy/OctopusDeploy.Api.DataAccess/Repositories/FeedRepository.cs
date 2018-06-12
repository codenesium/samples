using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.DataAccess
{
        public class FeedRepository: AbstractFeedRepository, IFeedRepository
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
    <Hash>c741b1cb79e140caa63c475e81ee8c28</Hash>
</Codenesium>*/