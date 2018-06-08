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
                        ServiceSettings settings,
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
    <Hash>85990cf60a186263fee822f533fc63a1</Hash>
</Codenesium>*/