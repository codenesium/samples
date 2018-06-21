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
        [Route("api/productSubcategories")]
        [ApiVersion("1.0")]
        public class ProductSubcategoryController : AbstractProductSubcategoryController
        {
                public ProductSubcategoryController(
                        ApiSettings settings,
                        ILogger<ProductSubcategoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductSubcategoryService productSubcategoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productSubcategoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5e3b9ee846716cae30b40649f8add634</Hash>
</Codenesium>*/