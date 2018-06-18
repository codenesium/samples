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
        [Route("api/countryRegions")]
        [ApiVersion("1.0")]
        public class CountryRegionController: AbstractCountryRegionController
        {
                public CountryRegionController(
                        ApiSettings settings,
                        ILogger<CountryRegionController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryRegionService countryRegionService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               countryRegionService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>aa01642377bfa6292097e0516ea0291a</Hash>
</Codenesium>*/