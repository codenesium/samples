using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
{
        [Route("api/countries")]
        [ApiVersion("1.0")]
        public class CountryController : AbstractCountryController
        {
                public CountryController(
                        ApiSettings settings,
                        ILogger<CountryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryService countryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               countryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2367fcf51b5416927bafba9f144dbb7f</Hash>
</Codenesium>*/