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
        [Route("api/salesTaxRates")]
        [ApiController]
        [ApiVersion("1.0")]
        public class SalesTaxRateController : AbstractSalesTaxRateController
        {
                public SalesTaxRateController(
                        ApiSettings settings,
                        ILogger<SalesTaxRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ISalesTaxRateService salesTaxRateService,
                        IApiSalesTaxRateModelMapper salesTaxRateModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               salesTaxRateService,
                               salesTaxRateModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7c703487f9c7a1a5af7e50ca7ad2bfba</Hash>
</Codenesium>*/