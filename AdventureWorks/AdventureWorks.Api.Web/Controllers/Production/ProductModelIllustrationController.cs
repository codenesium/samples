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
        [Route("api/productModelIllustrations")]
        [ApiVersion("1.0")]
        public class ProductModelIllustrationController: AbstractProductModelIllustrationController
        {
                public ProductModelIllustrationController(
                        ApiSettings settings,
                        ILogger<ProductModelIllustrationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductModelIllustrationService productModelIllustrationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productModelIllustrationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>45ede963f94ab925195b582282053e64</Hash>
</Codenesium>*/