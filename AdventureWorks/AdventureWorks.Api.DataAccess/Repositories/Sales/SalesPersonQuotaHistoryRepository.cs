using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesPersonQuotaHistoryRepository : AbstractSalesPersonQuotaHistoryRepository, ISalesPersonQuotaHistoryRepository
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
    <Hash>0ad7bb1b66ac69600954a7063192ab74</Hash>
</Codenesium>*/