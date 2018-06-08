using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.DataAccess
{
        public class ProductReviewRepository: AbstractProductReviewRepository, IProductReviewRepository
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
    <Hash>fca5a2b086a22800c1a5baf7d037335c</Hash>
</Codenesium>*/