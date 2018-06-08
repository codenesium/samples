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
                        ServiceSettings settings,
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
    <Hash>87990dfd691138cd9cb80be63e80b71b</Hash>
</Codenesium>*/