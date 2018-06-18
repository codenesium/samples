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
        [Route("api/otherTransports")]
        [ApiVersion("1.0")]
        public class OtherTransportController: AbstractOtherTransportController
        {
                public OtherTransportController(
                        ApiSettings settings,
                        ILogger<OtherTransportController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOtherTransportService otherTransportService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               otherTransportService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>93da96c70190e0fe5dff440e04950073</Hash>
</Codenesium>*/