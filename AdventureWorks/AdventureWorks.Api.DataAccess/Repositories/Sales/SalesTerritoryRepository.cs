using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>dc4dd2b1e35d21aa6934ece380c404c1</Hash>
</Codenesium>*/