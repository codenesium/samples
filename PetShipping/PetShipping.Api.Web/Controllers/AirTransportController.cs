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
        [ApiController]
        [ApiVersion("1.0")]
        public class AirTransportController : AbstractAirTransportController
        {
                public AirTransportController(
                        ApiSettings settings,
                        ILogger<AirTransportController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IAirTransportService airTransportService,
                        IApiAirTransportModelMapper airTransportModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               airTransportService,
                               airTransportModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>abb26b5be851041f8c63e29f48ddef25</Hash>
</Codenesium>*/