using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesPersonQuotaHistoryRepository : AbstractSalesPersonQuotaHistoryRepository, ISalesPersonQuotaHistoryRepository
        {
                public SalesPersonQuotaHistoryRepository(
                        ILogger<SalesPersonQuotaHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>015d683aa941fc13c71aefeb8a6d7c1a</Hash>
</Codenesium>*/