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
        [Route("api/airTransports")]
        [ApiVersion("1.0")]
        public class AirTransportController : AbstractAirTransportController
        {
                public AirTransportController(
                        ApiSettings settings,
                        ILogger<AirTransportController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAirTransportService airTransportService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               airTransportService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>9a12ac726f2ed5a0a24cc6083c67202f</Hash>
</Codenesium>*/