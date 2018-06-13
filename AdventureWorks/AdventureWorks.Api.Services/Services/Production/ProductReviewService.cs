using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;

namespace AdventureWorksNS.Api.Services
{
        public class ProductReviewService: AbstractProductReviewService, IProductReviewService
        {
                public ProductReviewService(
                        ILogger<ProductReviewRepository> logger,
                        IProductReviewRepository productReviewRepository,
                        IApiProductReviewRequestModelValidator productReviewModelValidator,
                        IBOLProductReviewMapper bolproductReviewMapper,
                        IDALProductReviewMapper dalproductReviewMapper

                        )
                        : base(logger,
                               productReviewRepository,
                               productReviewModelValidator,
                               bolproductReviewMapper,
                               dalproductReviewMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>b27868faaf29304d888754d9d1fdd545</Hash>
</Codenesium>*/