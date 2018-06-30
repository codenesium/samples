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
        [Route("api/products")]
        [ApiVersion("1.0")]
        public class ProductController : AbstractProductController
        {
                public ProductController(
                        ApiSettings settings,
                        ILogger<ProductController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductService productService,
                        IApiProductModelMapper productModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productService,
                               productModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f5c09bc988e6bec42ed8dbe85329fd9d</Hash>
</Codenesium>*/