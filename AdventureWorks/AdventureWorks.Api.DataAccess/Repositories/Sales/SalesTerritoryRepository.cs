using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class SalesTerritoryRepository : AbstractSalesTerritoryRepository, ISalesTerritoryRepository
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
    <Hash>4852441e7c006afa6b7382d4c33d73c8</Hash>
</Codenesium>*/