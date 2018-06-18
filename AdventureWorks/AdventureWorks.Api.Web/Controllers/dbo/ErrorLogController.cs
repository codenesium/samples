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
        [Route("api/errorLogs")]
        [ApiVersion("1.0")]
        public class ErrorLogController: AbstractErrorLogController
        {
                public ErrorLogController(
                        ApiSettings settings,
                        ILogger<ErrorLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IErrorLogService errorLogService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               errorLogService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>51d571fdf89a1ceec9efc3232d158439</Hash>
</Codenesium>*/