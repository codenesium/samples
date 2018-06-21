using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceRepository : AbstractSpaceRepository, ISpaceRepository
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
    <Hash>4c94253f5a4a4222528ee39c5f2e3636</Hash>
</Codenesium>*/