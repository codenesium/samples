using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductInventoryRepository: AbstractProductInventoryRepository, IProductInventoryRepository
        {
                public ProductInventoryRepository(
                        ILogger<ProductInventoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>0cc763a1748dd5dda650410119746fd5</Hash>
</Codenesium>*/