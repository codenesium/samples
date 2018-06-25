using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductInventoryRepository : AbstractProductInventoryRepository, IProductInventoryRepository
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
    <Hash>8383daa24a04dcfdea6d75fbb71751ba</Hash>
</Codenesium>*/