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
        [Route("api/currencyRates")]
        [ApiVersion("1.0")]
        public class CurrencyRateController : AbstractCurrencyRateController
        {
                public CurrencyRateController(
                        ApiSettings settings,
                        ILogger<CurrencyRateController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICurrencyRateService currencyRateService,
                        IApiCurrencyRateModelMapper currencyRateModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               currencyRateService,
                               currencyRateModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e258950c3d18cab6978a04ae90a4b89a</Hash>
</Codenesium>*/