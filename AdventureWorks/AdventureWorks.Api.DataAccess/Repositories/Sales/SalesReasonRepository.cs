using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesReasonRepository : AbstractSalesReasonRepository, ISalesReasonRepository
        {
                public SalesReasonRepository(
                        ILogger<SalesReasonRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>cfc8b101faa1dd38f570605b42855497</Hash>
</Codenesium>*/