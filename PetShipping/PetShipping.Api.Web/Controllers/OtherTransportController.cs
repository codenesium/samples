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
        [Route("api/otherTransports")]
        [ApiVersion("1.0")]
        public class OtherTransportController : AbstractOtherTransportController
        {
                public OtherTransportController(
                        ApiSettings settings,
                        ILogger<OtherTransportController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IOtherTransportService otherTransportService,
                        IApiOtherTransportModelMapper otherTransportModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               otherTransportService,
                               otherTransportModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>2735d063ddbc2cecde7028a422fe9576</Hash>
</Codenesium>*/