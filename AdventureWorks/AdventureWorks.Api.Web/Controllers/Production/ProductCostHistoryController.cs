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
        [ApiVersion("1.0")]
        public class ProductCostHistoryController : AbstractProductCostHistoryController
        {
                public ProductCostHistoryController(
                        ApiSettings settings,
                        ILogger<ProductCostHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductCostHistoryService productCostHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productCostHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b486a495ab85dd7249d6b35f3aeb944a</Hash>
</Codenesium>*/