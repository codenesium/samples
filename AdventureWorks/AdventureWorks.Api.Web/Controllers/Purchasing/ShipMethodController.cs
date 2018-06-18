using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using AdventureWorksNS.Api.Contracts;
using AdventureWorksNS.Api.Services;

namespace AdventureWorksNS.Api.Web
{
        [Route("api/shipMethods")]
        [ApiVersion("1.0")]
        public class ShipMethodController: AbstractShipMethodController
        {
                public ShipMethodController(
                        ApiSettings settings,
                        ILogger<ShipMethodController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IShipMethodService shipMethodService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               shipMethodService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5441b8c3913e81e249ffc4c4bff163c7</Hash>
</Codenesium>*/