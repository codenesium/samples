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
        [Route("api/productProductPhotoes")]
        [ApiVersion("1.0")]
        public class ProductProductPhotoController: AbstractProductProductPhotoController
        {
                public ProductProductPhotoController(
                        ServiceSettings settings,
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
    <Hash>142cfc3f839427991400eaa87fef8e80</Hash>
</Codenesium>*/