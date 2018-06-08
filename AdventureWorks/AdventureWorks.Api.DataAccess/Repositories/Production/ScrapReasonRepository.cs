using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ScrapReasonRepository: AbstractScrapReasonRepository, IScrapReasonRepository
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
    <Hash>11b8aecaabc47737b8a7059a3dfee741</Hash>
</Codenesium>*/