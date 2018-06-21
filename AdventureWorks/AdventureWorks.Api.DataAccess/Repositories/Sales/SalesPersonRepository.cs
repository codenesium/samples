using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesPersonRepository : AbstractSalesPersonRepository, ISalesPersonRepository
        {
                public SalesPersonRepository(
                        ILogger<SalesPersonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>bbcf2940ae15951826f477e7a5ddb517</Hash>
</Codenesium>*/