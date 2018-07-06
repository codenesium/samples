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
        [Route("api/productCostHistories")]
        [ApiController]
        [ApiVersion("1.0")]
        public class ProductCostHistoryController : AbstractProductCostHistoryController
        {
                public ProductCostHistoryController(
                        ApiSettings settings,
                        ILogger<ProductCostHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductCostHistoryService productCostHistoryService,
                        IApiProductCostHistoryModelMapper productCostHistoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productCostHistoryService,
                               productCostHistoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0fbbac9f5f9e7bac2c7a3a31a7a82ae4</Hash>
</Codenesium>*/