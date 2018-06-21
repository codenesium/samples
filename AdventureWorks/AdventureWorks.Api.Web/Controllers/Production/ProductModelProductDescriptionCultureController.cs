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
        [Route("api/productModelProductDescriptionCultures")]
        [ApiVersion("1.0")]
        public class ProductModelProductDescriptionCultureController : AbstractProductModelProductDescriptionCultureController
        {
                public ProductModelProductDescriptionCultureController(
                        ApiSettings settings,
                        ILogger<ProductModelProductDescriptionCultureController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductModelProductDescriptionCultureService productModelProductDescriptionCultureService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productModelProductDescriptionCultureService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7bed60cc825435470eaa8739d3f226bd</Hash>
</Codenesium>*/