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
        [Route("api/productModels")]
        [ApiVersion("1.0")]
        public class ProductModelController : AbstractProductModelController
        {
                public ProductModelController(
                        ApiSettings settings,
                        ILogger<ProductModelController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IProductModelService productModelService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               productModelService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a5869ac855e1f3361acefea97ff6b150</Hash>
</Codenesium>*/