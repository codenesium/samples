using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductCostHistoryRepository : AbstractProductCostHistoryRepository, IProductCostHistoryRepository
        {
                public ProductCostHistoryRepository(
                        ILogger<ProductCostHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>a97da5a845f3b821ab59b7a86608e4e2</Hash>
</Codenesium>*/