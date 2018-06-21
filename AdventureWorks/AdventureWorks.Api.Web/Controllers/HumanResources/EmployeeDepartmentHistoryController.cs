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
        [Route("api/employeeDepartmentHistories")]
        [ApiVersion("1.0")]
        public class EmployeeDepartmentHistoryController : AbstractEmployeeDepartmentHistoryController
        {
                public EmployeeDepartmentHistoryController(
                        ApiSettings settings,
                        ILogger<EmployeeDepartmentHistoryController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeeDepartmentHistoryService employeeDepartmentHistoryService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               employeeDepartmentHistoryService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>c36e2b1a792417a6dd74ed5e9878907a</Hash>
</Codenesium>*/