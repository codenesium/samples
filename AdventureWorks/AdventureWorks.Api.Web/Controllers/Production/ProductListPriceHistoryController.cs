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
                        IProductListPriceHistoryService productListPriceHistoryService,
                        IApiProductListPriceHistoryModelMapper productListPriceHistoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productListPriceHistoryService,
                               productListPriceHistoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>d0c4bec7f10c747ca08cd2a1b0db30e4</Hash>
</Codenesium>*/