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
                        ServiceSettings settings,
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
    <Hash>371c152f54f8b4881bf65801306a1d8a</Hash>
</Codenesium>*/