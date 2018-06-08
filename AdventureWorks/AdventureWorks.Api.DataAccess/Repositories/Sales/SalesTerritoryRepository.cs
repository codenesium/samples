using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesTerritoryRepository: AbstractSalesTerritoryRepository, ISalesTerritoryRepository
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
    <Hash>d3fdb63022b3cf6b5f9f7f6e0f4b8d08</Hash>
</Codenesium>*/