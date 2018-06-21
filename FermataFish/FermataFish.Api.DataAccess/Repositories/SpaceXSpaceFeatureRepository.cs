using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceXSpaceFeatureRepository : AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
        {
                public SpaceXSpaceFeatureRepository(
                        ILogger<SpaceXSpaceFeatureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e1b85e6c10c80d24858112b1e9079072</Hash>
</Codenesium>*/