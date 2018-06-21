using Codenesium.DataConversionExtensions;
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
    <Hash>728d6f8bfe9ac5a4a9ab3c1de36c31d1</Hash>
</Codenesium>*/