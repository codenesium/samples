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
        [Route("api/productCategories")]
        [ApiController]
        [ApiVersion("1.0")]
        public class ProductCategoryController : AbstractProductCategoryController
        {
                public ProductCategoryController(
                        ApiSettings settings,
                        ILogger<ProductCategoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductCategoryService productCategoryService,
                        IApiProductCategoryModelMapper productCategoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productCategoryService,
                               productCategoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>937ec8b1663c420c32aec88101bc4403</Hash>
</Codenesium>*/