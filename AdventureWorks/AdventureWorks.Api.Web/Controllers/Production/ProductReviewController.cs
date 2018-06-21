using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/productReviews")]
        [ApiVersion("1.0")]
        public class ProductReviewController : AbstractProductReviewController
        {
                public ProductReviewController(
                        ApiSettings settings,
                        ILogger<ProductReviewController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductReviewService productReviewService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productReviewService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>bb19f5832633114cf1a72a1056b8a36a</Hash>
</Codenesium>*/