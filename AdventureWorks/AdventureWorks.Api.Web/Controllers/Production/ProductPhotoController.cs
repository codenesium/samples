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
        [Route("api/productPhotoes")]
        [ApiVersion("1.0")]
        public class ProductPhotoController : AbstractProductPhotoController
        {
                public ProductPhotoController(
                        ApiSettings settings,
                        ILogger<ProductPhotoController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductPhotoService productPhotoService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productPhotoService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f29892477f76289801fee67d8a9b0949</Hash>
</Codenesium>*/