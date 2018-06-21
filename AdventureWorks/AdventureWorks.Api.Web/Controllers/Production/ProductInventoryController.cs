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
        [Route("api/productInventories")]
        [ApiVersion("1.0")]
        public class ProductInventoryController : AbstractProductInventoryController
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
    <Hash>98800a364151672e57ca0988d9e7e383</Hash>
</Codenesium>*/