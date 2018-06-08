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
                        ServiceSettings settings,
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
    <Hash>3f7df593c9ded8ab57ab2c422eb5e21b</Hash>
</Codenesium>*/