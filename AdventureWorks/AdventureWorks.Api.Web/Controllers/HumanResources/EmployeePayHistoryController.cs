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
        [Route("api/employeePayHistories")]
        [ApiVersion("1.0")]
        public class EmployeePayHistoryController: AbstractEmployeePayHistoryController
        {
                public EmployeePayHistoryController(
                        ApiSettings settings,
                        ILogger<EmployeePayHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeePayHistoryService employeePayHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               employeePayHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>b72e97588d24849853edc53597bcfcbd</Hash>
</Codenesium>*/