using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace FermataFishNS.Api.DataAccess
{
        public class StudioRepository : AbstractStudioRepository, IStudioRepository
        {
                public StudioRepository(
                        ILogger<StudioRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>141e0cf774ef0f2ed5fc709940069ae6</Hash>
</Codenesium>*/