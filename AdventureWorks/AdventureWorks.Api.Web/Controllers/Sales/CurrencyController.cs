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
        [Route("api/currencies")]
        [ApiVersion("1.0")]
        public class CurrencyController : AbstractCurrencyController
        {
                public CurrencyController(
                        ApiSettings settings,
                        ILogger<CurrencyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICurrencyService currencyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               currencyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>492d41c62a7df84c56ba07aff4313395</Hash>
</Codenesium>*/