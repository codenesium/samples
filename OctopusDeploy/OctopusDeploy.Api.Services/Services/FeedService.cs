using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using OctopusDeployNS.Api.Contracts;
using OctopusDeployNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace OctopusDeployNS.Api.Services
{
        public class FeedService : AbstractFeedService, IFeedService
        {
                public FeedService(
                        ILogger<IFeedRepository> logger,
                        IFeedRepository feedRepository,
                        IApiFeedRequestModelValidator feedModelValidator,
                        IBOLFeedMapper bolfeedMapper,
                        IDALFeedMapper dalfeedMapper
                        )
                        : base(logger,
                               feedRepository,
                               feedModelValidator,
                               bolfeedMapper,
                               dalfeedMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>6a68844c64a0ca744c007da1e9d1f197</Hash>
</Codenesium>*/