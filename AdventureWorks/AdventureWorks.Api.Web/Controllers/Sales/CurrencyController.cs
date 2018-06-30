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
                        ICurrencyService currencyService,
                        IApiCurrencyModelMapper currencyModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               currencyService,
                               currencyModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a64736fe910911278557c5078a3c9f7d</Hash>
</Codenesium>*/