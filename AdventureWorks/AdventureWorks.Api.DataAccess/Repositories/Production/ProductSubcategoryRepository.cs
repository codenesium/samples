using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductSubcategoryRepository : AbstractProductSubcategoryRepository, IProductSubcategoryRepository
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
    <Hash>7a55096762fe3b508c18f32889f5adc0</Hash>
</Codenesium>*/