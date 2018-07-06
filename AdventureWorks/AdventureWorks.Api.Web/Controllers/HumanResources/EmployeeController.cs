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
        [ApiController]
        [ApiVersion("1.0")]
        public class EmployeeController : AbstractEmployeeController
        {
                public EmployeeController(
                        ApiSettings settings,
                        ILogger<EmployeeController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IEmployeeService employeeService,
                        IApiEmployeeModelMapper employeeModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               employeeService,
                               employeeModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>42cddd2eb3592e91597b8f7bfbb74eb4</Hash>
</Codenesium>*/