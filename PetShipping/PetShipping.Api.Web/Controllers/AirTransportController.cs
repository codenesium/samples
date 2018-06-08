using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;

namespace PetShippingNS.Api.Web
{
        [Route("api/airTransports")]
        [ApiVersion("1.0")]
        public class AirTransportController: AbstractAirTransportController
        {
                public AirTransportController(
                        ServiceSettings settings,
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
    <Hash>b164191ca083be5b45aa7cb773da278d</Hash>
</Codenesium>*/