using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductCostHistoryRepository : AbstractProductCostHistoryRepository, IProductCostHistoryRepository
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
    <Hash>f3f2961c46439f2b3ebe6e4522e19ae0</Hash>
</Codenesium>*/