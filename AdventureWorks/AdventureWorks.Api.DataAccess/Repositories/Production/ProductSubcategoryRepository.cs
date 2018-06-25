using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductSubcategoryRepository : AbstractProductSubcategoryRepository, IProductSubcategoryRepository
        {
                public ProductSubcategoryRepository(
                        ILogger<ProductSubcategoryRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>36476beb81d9759d644255c413ec8f17</Hash>
</Codenesium>*/