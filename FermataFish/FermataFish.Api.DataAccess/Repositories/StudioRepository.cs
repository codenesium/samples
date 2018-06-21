using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>686043eb7c52187d09ac3fe566cfbdbd</Hash>
</Codenesium>*/