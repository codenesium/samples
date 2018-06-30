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
    <Hash>f4b99687b5b64d276523f11b036d95ae</Hash>
</Codenesium>*/