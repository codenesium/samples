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
        [Route("api/productDescriptions")]
        [ApiVersion("1.0")]
        public class ProductDescriptionController : AbstractProductDescriptionController
        {
                public ProductDescriptionController(
                        ApiSettings settings,
                        ILogger<ProductDescriptionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductDescriptionService productDescriptionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productDescriptionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ce46da82ec277d3bdd321019bde7b7ef</Hash>
</Codenesium>*/