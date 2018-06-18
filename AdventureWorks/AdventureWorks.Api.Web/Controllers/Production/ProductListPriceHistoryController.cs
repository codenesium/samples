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
        [Route("api/productListPriceHistories")]
        [ApiVersion("1.0")]
        public class ProductListPriceHistoryController: AbstractProductListPriceHistoryController
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
    <Hash>963f32aefa0ee5802832439f8e9ed690</Hash>
</Codenesium>*/