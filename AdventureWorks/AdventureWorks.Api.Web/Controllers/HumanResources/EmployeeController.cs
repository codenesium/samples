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
        [Route("api/employees")]
        [ApiVersion("1.0")]
        public class EmployeeController : AbstractEmployeeController
        {
                public EmployeeController(
                        ApiSettings settings,
                        ILogger<EmployeeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeeService employeeService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               employeeService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>208a657f89c77bcf2a1864eb3a6fee73</Hash>
</Codenesium>*/