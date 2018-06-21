using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>4d8198b9b48977966985295884d670ae</Hash>
</Codenesium>*/