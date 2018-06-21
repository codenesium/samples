using Codenesium.DataConversionExtensions;
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
    <Hash>cb7095f59bef3a4f802f475fd2db301f</Hash>
</Codenesium>*/