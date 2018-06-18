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
        [Route("api/countryRegionCurrencies")]
        [ApiVersion("1.0")]
        public class CountryRegionCurrencyController: AbstractCountryRegionCurrencyController
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
    <Hash>4ab33f3f8ab0ef51ccfe2ab724fb0860</Hash>
</Codenesium>*/