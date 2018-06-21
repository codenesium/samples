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
        [ApiVersion("1.0")]
        public class ProductCategoryController : AbstractProductCategoryController
        {
                public ProductCategoryController(
                        ApiSettings settings,
                        ILogger<ProductCategoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductCategoryService productCategoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productCategoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>de388ca92e02969e1a10410c30b543ce</Hash>
</Codenesium>*/