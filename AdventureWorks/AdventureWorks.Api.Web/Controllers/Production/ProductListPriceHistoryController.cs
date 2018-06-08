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
                        ServiceSettings settings,
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
    <Hash>e0faddf75fa62e69e35bbc22f43e6c4e</Hash>
</Codenesium>*/