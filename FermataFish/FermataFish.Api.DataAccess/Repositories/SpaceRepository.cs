using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public partial class SpaceRepository : AbstractSpaceRepository, ISpaceRepository
        {
                public SpaceRepository(
                        ILogger<SpaceRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>39be150d549caf984bc1d1b783349c55</Hash>
</Codenesium>*/