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
        [Route("api/salesTaxRates")]
        [ApiVersion("1.0")]
        public class SalesTaxRateController: AbstractSalesTaxRateController
        {
                public SalesTaxRateController(
                        ApiSettings settings,
                        ILogger<SalesTaxRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTaxRateService salesTaxRateService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTaxRateService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>ded13a27194c58c3c8e7baa8258d55b6</Hash>
</Codenesium>*/