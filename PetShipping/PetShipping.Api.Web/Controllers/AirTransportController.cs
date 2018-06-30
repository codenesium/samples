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
    <Hash>1d9297686f557794b38be8d790ed852c</Hash>
</Codenesium>*/