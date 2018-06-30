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
        public partial class FeedService : AbstractFeedService, IFeedService
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
    <Hash>7e80efe9619acec57e7743c95b807a07</Hash>
</Codenesium>*/