using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesTerritoryHistoryRepository : AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
        {
                public SalesTerritoryHistoryRepository(
                        ILogger<SalesTerritoryHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>07c890172d7f2fc0db6c733cdbb2af67</Hash>
</Codenesium>*/