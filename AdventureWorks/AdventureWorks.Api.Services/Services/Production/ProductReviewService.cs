using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.DataAccess;
using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;

namespace AdventureWorksNS.Api.Services
{
        public class ProductReviewService : AbstractProductReviewService, IProductReviewService
        {
                public ProductReviewService(
                        ILogger<IProductReviewRepository> logger,
                        IProductReviewRepository productReviewRepository,
                        IApiProductReviewRequestModelValidator productReviewModelValidator,
                        IBOLProductReviewMapper bolproductReviewMapper,
                        IDALProductReviewMapper dalproductReviewMapper
                        )
                        : base(logger,
                               productReviewRepository,
                               productReviewModelValidator,
                               bolproductReviewMapper,
                               dalproductReviewMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>5b82bf412d59de433cdea3c30b2e5ebb</Hash>
</Codenesium>*/