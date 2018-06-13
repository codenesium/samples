using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;

namespace OctopusDeployNS.Api.Services
{
        public class FeedService: AbstractFeedService, IFeedService
        {
                public FeedService(
                        ILogger<FeedRepository> logger,
                        IFeedRepository feedRepository,
                        IApiFeedRequestModelValidator feedModelValidator,
                        IBOLFeedMapper bolfeedMapper,
                        IDALFeedMapper dalfeedMapper

                        )
                        : base(logger,
                               feedRepository,
                               feedModelValidator,
                               bolfeedMapper,
                               dalfeedMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>1b3402931e5a697773c0ad0f3ae669f8</Hash>
</Codenesium>*/