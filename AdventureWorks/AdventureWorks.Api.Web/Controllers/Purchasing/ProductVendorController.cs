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
        [Route("api/productVendors")]
        [ApiVersion("1.0")]
        public class ProductVendorController: AbstractProductVendorController
        {
                public ProductVendorController(
                        ServiceSettings settings,
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
    <Hash>ee2cda2e85e5c5c57cfc5c6b5c3f161c</Hash>
</Codenesium>*/