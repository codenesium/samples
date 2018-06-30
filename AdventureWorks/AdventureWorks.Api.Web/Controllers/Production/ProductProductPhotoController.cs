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
                        IProductProductPhotoService productProductPhotoService,
                        IApiProductProductPhotoModelMapper productProductPhotoModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productProductPhotoService,
                               productProductPhotoModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>021adf1dd3ed3ba9d12327276b9390c4</Hash>
</Codenesium>*/