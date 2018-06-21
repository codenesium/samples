using Codenesium.DataConversionExtensions;
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
    <Hash>b45c207ef3efdb3fd0dcd805ca42cf54</Hash>
</Codenesium>*/