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
                        ServiceSettings settings,
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
    <Hash>c461a976b06a5b9815a7f5bba7196dc2</Hash>
</Codenesium>*/