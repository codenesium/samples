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
        [Route("api/cities")]
        [ApiController]
        [ApiVersion("1.0")]
        public class CityController : AbstractCityController
        {
                public CityController(
                        ApiSettings settings,
                        ILogger<CityController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ICityService cityService,
                        IApiCityModelMapper cityModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               cityService,
                               cityModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>dcc0dbbe7e6dadcd95dd05dda0e210a6</Hash>
</Codenesium>*/