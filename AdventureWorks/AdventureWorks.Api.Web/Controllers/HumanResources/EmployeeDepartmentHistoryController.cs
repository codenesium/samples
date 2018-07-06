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
        [ApiController]
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
    <Hash>9fd59d9d573a8d0a432a0cc2ef2d6c39</Hash>
</Codenesium>*/