using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceXSpaceFeatureRepository: AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
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
    <Hash>2cae91f6a5ff7dc5b4ce3035386ba0c0</Hash>
</Codenesium>*/