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
        [Route("api/countryRegions")]
        [ApiVersion("1.0")]
        public class CountryRegionController : AbstractCountryRegionController
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
    <Hash>5bf86ab68cc3a58457e1ed6f51b7f8f8</Hash>
</Codenesium>*/