using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class SpaceXSpaceFeatureRepository : AbstractSpaceXSpaceFeatureRepository, ISpaceXSpaceFeatureRepository
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
    <Hash>cde763ca67c15263f5ea50699651db6d</Hash>
</Codenesium>*/