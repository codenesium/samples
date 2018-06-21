using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductInventoryRepository : AbstractProductInventoryRepository, IProductInventoryRepository
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
    <Hash>b088103bc39bd456cd397210e896d71c</Hash>
</Codenesium>*/