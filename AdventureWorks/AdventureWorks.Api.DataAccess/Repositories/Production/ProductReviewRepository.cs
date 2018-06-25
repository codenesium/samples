using Codenesium.DataConversionExtensions;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public partial class ProductReviewRepository : AbstractProductReviewRepository, IProductReviewRepository
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
    <Hash>4f22edd7b59dcb6e85bf633145385916</Hash>
</Codenesium>*/