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
        [Route("api/employeeDepartmentHistories")]
        [ApiVersion("1.0")]
        public class EmployeeDepartmentHistoryController: AbstractEmployeeDepartmentHistoryController
        {
                public EmployeeDepartmentHistoryController(
                        ServiceSettings settings,
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
    <Hash>05977d74d534742246e7c9e1689b4544</Hash>
</Codenesium>*/