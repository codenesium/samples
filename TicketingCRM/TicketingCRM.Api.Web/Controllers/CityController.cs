using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TicketingCRMNS.Api.Contracts;
using TicketingCRMNS.Api.Services;

namespace TicketingCRMNS.Api.Web
{
        [Route("api/cities")]
        [ApiVersion("1.0")]
        public class CityController: AbstractCityController
        {
                public CityController(
                        ServiceSettings settings,
                        ILogger<CityController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICityService cityService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               cityService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a8a9cd6dd8c615342d159ed6083c1b0b</Hash>
</Codenesium>*/