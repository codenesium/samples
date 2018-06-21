using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductListPriceHistoryRepository : AbstractProductListPriceHistoryRepository, IProductListPriceHistoryRepository
        {
                public ProductListPriceHistoryRepository(
                        ILogger<ProductListPriceHistoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>65e94ce1488cdf56eec09b33f49bc6ba</Hash>
</Codenesium>*/