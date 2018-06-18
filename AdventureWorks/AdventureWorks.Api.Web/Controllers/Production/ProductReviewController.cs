using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/productReviews")]
        [ApiVersion("1.0")]
        public class ProductReviewController: AbstractProductReviewController
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
    <Hash>09f9f0f4333785d36cdaa8f56992f42a</Hash>
</Codenesium>*/