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
        [Route("api/shifts")]
        [ApiVersion("1.0")]
        public class ShiftController: AbstractShiftController
        {
                public ShiftController(
                        ServiceSettings settings,
                        ILogger<ShiftController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IShiftService shiftService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               shiftService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>a3c7b1766a10f749dbcbb8e1b0976444</Hash>
</Codenesium>*/