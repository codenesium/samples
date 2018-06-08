using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductCostHistoryRepository: AbstractProductCostHistoryRepository, IProductCostHistoryRepository
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
    <Hash>080f30bb2b7442158db92068285d43bb</Hash>
</Codenesium>*/