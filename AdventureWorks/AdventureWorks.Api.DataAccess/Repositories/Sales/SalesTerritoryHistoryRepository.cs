using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesTerritoryHistoryRepository : AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
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
    <Hash>34859b7bbaa57a96c7ce3231b2593ee1</Hash>
</Codenesium>*/