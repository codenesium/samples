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
        [Route("api/products")]
        [ApiVersion("1.0")]
        public class ProductController: AbstractProductController
        {
                public ProductController(
                        ApiSettings settings,
                        ILogger<ProductController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductService productService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>bff63ae051338807e69d13610a55d9c1</Hash>
</Codenesium>*/