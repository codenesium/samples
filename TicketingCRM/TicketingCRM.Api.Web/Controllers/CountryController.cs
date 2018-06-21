using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
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
    <Hash>41edd8da646a1d4761c49cb9fe37dc47</Hash>
</Codenesium>*/