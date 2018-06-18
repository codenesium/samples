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
                               dalfeedMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>f2b861b6a48eb1881b68d581c4633bfb</Hash>
</Codenesium>*/