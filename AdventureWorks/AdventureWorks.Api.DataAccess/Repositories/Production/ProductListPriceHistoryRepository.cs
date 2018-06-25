using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductListPriceHistoryRepository : AbstractProductListPriceHistoryRepository, IProductListPriceHistoryRepository
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
    <Hash>69817cfb3325aef7dc4adc8a0dfe696a</Hash>
</Codenesium>*/