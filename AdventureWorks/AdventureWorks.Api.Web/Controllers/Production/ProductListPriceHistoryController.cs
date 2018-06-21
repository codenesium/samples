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
        [Route("api/productListPriceHistories")]
        [ApiVersion("1.0")]
        public class ProductListPriceHistoryController : AbstractProductListPriceHistoryController
        {
                public ProductListPriceHistoryController(
                        ApiSettings settings,
                        ILogger<ProductListPriceHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductListPriceHistoryService productListPriceHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productListPriceHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d3aadb4be618c98eb68bb343924e0647</Hash>
</Codenesium>*/