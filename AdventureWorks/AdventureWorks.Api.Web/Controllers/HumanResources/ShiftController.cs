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
        [Route("api/shifts")]
        [ApiVersion("1.0")]
        public class ShiftController : AbstractShiftController
        {
                public ShiftController(
                        ApiSettings settings,
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
    <Hash>75344f40945ea6ee1cf7377168db2db1</Hash>
</Codenesium>*/