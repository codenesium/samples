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
        [Route("api/productInventories")]
        [ApiVersion("1.0")]
        public class ProductInventoryController: AbstractProductInventoryController
        {
                public ProductInventoryController(
                        ApiSettings settings,
                        ILogger<ProductInventoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductInventoryService productInventoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productInventoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1ea824fd00b5fb9ae2e908932c79b247</Hash>
</Codenesium>*/