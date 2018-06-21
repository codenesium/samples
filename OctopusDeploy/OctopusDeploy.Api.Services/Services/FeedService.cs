using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>774033263f5b19620df40b422b9e6f6c</Hash>
</Codenesium>*/