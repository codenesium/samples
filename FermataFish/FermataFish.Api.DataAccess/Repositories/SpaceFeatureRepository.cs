using Codenesium.DataConversionExtensions;
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
    <Hash>6280f472e7072207372ad379248c6772</Hash>
</Codenesium>*/