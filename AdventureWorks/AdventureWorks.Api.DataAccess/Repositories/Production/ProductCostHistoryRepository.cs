using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>5f87451f4315c5f679b8fb3c340e1f82</Hash>
</Codenesium>*/