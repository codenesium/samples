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
        [Route("api/productModelProductDescriptionCultures")]
        [ApiVersion("1.0")]
        public class ProductModelProductDescriptionCultureController: AbstractProductModelProductDescriptionCultureController
        {
                public ProductModelProductDescriptionCultureController(
                        ServiceSettings settings,
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
    <Hash>ac6e224478ff3d20920cef3942ad47f7</Hash>
</Codenesium>*/