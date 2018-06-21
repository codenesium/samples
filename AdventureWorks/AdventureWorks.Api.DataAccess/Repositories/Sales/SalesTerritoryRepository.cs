using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesTerritoryRepository : AbstractSalesTerritoryRepository, ISalesTerritoryRepository
        {
                public SalesTerritoryRepository(
                        ILogger<SalesTerritoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>d4b580c7fa38772b67f71aa901c1b734</Hash>
</Codenesium>*/