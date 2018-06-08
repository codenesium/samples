using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class SpaceRepository: AbstractSpaceRepository, ISpaceRepository
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
    <Hash>e0070d92375b0e45a427899f6440550a</Hash>
</Codenesium>*/