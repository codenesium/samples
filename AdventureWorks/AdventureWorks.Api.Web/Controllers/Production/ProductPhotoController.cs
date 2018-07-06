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
        [ApiController]
        [ApiVersion("1.0")]
        public class ProductPhotoController : AbstractProductPhotoController
        {
                public ProductPhotoController(
                        ApiSettings settings,
                        ILogger<ProductPhotoController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductPhotoService productPhotoService,
                        IApiProductPhotoModelMapper productPhotoModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productPhotoService,
                               productPhotoModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7223d59b78601f0c82eaf194eca148e0</Hash>
</Codenesium>*/