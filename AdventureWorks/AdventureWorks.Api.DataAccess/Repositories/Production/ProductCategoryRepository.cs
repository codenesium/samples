using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductCategoryRepository : AbstractProductCategoryRepository, IProductCategoryRepository
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
    <Hash>92a25e93092fd2ad2f511477a7b86cf6</Hash>
</Codenesium>*/