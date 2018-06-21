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
        [Route("api/productProductPhotoes")]
        [ApiVersion("1.0")]
        public class ProductProductPhotoController : AbstractProductProductPhotoController
        {
                public ProductProductPhotoController(
                        ApiSettings settings,
                        ILogger<ProductProductPhotoController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductProductPhotoService productProductPhotoService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productProductPhotoService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c67aaa67290d82e69a7b6dd8adf4dc4f</Hash>
</Codenesium>*/