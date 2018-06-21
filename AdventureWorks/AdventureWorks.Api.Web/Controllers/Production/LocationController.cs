using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/locations")]
        [ApiVersion("1.0")]
        public class LocationController : AbstractLocationController
        {
                public LocationController(
                        ApiSettings settings,
                        ILogger<LocationController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILocationService locationService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               locationService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>993888db542b09c469afb2382533b07b</Hash>
</Codenesium>*/