using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class SpaceFeatureRepository : AbstractSpaceFeatureRepository, ISpaceFeatureRepository
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
    <Hash>35c4e955bccd3624552272f350fbf63d</Hash>
</Codenesium>*/