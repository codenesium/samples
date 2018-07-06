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
        [ApiController]
        [ApiVersion("1.0")]
        public class CountryController : AbstractCountryController
        {
                public CountryController(
                        ApiSettings settings,
                        ILogger<CountryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICountryService countryService,
                        IApiCountryModelMapper countryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               countryService,
                               countryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>afe5db2bd35703f5d5b9bd1ac39faab6</Hash>
</Codenesium>*/