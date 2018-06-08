using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceFeatureRepository: AbstractSpaceFeatureRepository, ISpaceFeatureRepository
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
    <Hash>531a1099874f7ac9de90caaad93b5e45</Hash>
</Codenesium>*/