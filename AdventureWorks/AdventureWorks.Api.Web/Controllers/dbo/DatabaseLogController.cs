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
        [Route("api/databaseLogs")]
        [ApiVersion("1.0")]
        public class DatabaseLogController : AbstractDatabaseLogController
        {
                public DatabaseLogController(
                        ApiSettings settings,
                        ILogger<DatabaseLogController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDatabaseLogService databaseLogService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               databaseLogService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>714960b554874fa96fbb8401cbb006cc</Hash>
</Codenesium>*/