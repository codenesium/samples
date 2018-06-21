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
        [Route("api/airlines")]
        [ApiVersion("1.0")]
        public class AirlineController : AbstractAirlineController
        {
                public AirlineController(
                        ApiSettings settings,
                        ILogger<AirlineController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAirlineService airlineService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               airlineService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f983a61dff0b5a660279ab9f14ec8edb</Hash>
</Codenesium>*/