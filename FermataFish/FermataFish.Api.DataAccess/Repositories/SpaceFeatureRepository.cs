using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceFeatureRepository : AbstractSpaceFeatureRepository, ISpaceFeatureRepository
        {
                public SpaceFeatureRepository(
                        ILogger<SpaceFeatureRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>244c3b95e808d42cfa3a0a4a1a5b10a2</Hash>
</Codenesium>*/