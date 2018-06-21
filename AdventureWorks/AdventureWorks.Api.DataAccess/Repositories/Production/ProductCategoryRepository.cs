using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductCategoryRepository : AbstractProductCategoryRepository, IProductCategoryRepository
        {
                public ProductCategoryRepository(
                        ILogger<ProductCategoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5aabe6f5682e4b8c85317f3d439cf522</Hash>
</Codenesium>*/