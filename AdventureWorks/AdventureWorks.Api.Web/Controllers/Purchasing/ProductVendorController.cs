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
        [Route("api/productVendors")]
        [ApiVersion("1.0")]
        public class ProductVendorController : AbstractProductVendorController
        {
                public ProductVendorController(
                        ApiSettings settings,
                        ILogger<ProductVendorController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductVendorService productVendorService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productVendorService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>071c156efa8976a7c1da257da6e1f7e5</Hash>
</Codenesium>*/