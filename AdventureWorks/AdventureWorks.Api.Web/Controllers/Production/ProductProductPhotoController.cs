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
        [ApiController]
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
    <Hash>c8e2d851a48bbe3d5e17df703f55d95a</Hash>
</Codenesium>*/