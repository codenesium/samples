using Codenesium.DataConversionExtensions.AspNetCore;
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
    <Hash>8fea72fe6a2386629e318bd87950ec96</Hash>
</Codenesium>*/