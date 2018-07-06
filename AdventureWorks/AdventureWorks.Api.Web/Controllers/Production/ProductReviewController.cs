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
        [ApiController]
        [ApiVersion("1.0")]
        public class ProductReviewController : AbstractProductReviewController
        {
                public ProductReviewController(
                        ApiSettings settings,
                        ILogger<ProductReviewController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductReviewService productReviewService,
                        IApiProductReviewModelMapper productReviewModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productReviewService,
                               productReviewModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b553a164ff2857fa6b4e7296d50c6a4b</Hash>
</Codenesium>*/