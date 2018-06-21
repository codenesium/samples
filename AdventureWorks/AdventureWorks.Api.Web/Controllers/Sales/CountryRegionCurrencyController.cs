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
        [Route("api/countryRegionCurrencies")]
        [ApiVersion("1.0")]
        public class CountryRegionCurrencyController : AbstractCountryRegionCurrencyController
        {
                public CountryRegionCurrencyController(
                        ApiSettings settings,
                        ILogger<CountryRegionCurrencyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryRegionCurrencyService countryRegionCurrencyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               countryRegionCurrencyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3fd3a626d93bce1cbefe8e111733f5e3</Hash>
</Codenesium>*/