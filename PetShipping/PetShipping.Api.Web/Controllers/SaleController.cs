using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
        [Route("api/sales")]
        [ApiVersion("1.0")]
        public class SaleController : AbstractSaleController
        {
                public SaleController(
                        ApiSettings settings,
                        ILogger<SaleController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISaleService saleService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               saleService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>8b72237e56acb172ea186b89fb8605df</Hash>
</Codenesium>*/