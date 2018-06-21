using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductReviewRepository : AbstractProductReviewRepository, IProductReviewRepository
        {
                public ProductReviewRepository(
                        ILogger<ProductReviewRepository> logger,
                        ApplicationDbContext context)
                        : base(logger, context)
                {
                }
        }
}

/*<Codenesium>
    <Hash>e69711d2dcf213053db0b426a8312f21</Hash>
</Codenesium>*/