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
        [Route("api/productPhotoes")]
        [ApiVersion("1.0")]
        public class ProductPhotoController: AbstractProductPhotoController
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
    <Hash>439781b6be8d76c0c88cd0066a225e70</Hash>
</Codenesium>*/