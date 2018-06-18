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
                        ApiSettings settings,
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
    <Hash>d55cbe7b54c5a8713469b7360669621b</Hash>
</Codenesium>*/