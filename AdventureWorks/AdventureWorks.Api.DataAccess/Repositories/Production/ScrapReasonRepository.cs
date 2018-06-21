using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ScrapReasonRepository : AbstractScrapReasonRepository, IScrapReasonRepository
        {
                public ScrapReasonRepository(
                        ILogger<ScrapReasonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>72e87849fab82b2d6c3338c5432ca172</Hash>
</Codenesium>*/