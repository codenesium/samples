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
                        IEmployeeDepartmentHistoryService employeeDepartmentHistoryService,
                        IApiEmployeeDepartmentHistoryModelMapper employeeDepartmentHistoryModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               employeeDepartmentHistoryService,
                               employeeDepartmentHistoryModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>1abf6b48f6f4804d8fccf8f75f208b64</Hash>
</Codenesium>*/