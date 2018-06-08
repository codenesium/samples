using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class SalesTerritoryHistoryRepository: AbstractSalesTerritoryHistoryRepository, ISalesTerritoryHistoryRepository
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
    <Hash>87396fc361a2d585ecdcdbce882de64b</Hash>
</Codenesium>*/