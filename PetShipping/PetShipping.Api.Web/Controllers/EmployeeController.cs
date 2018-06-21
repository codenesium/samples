using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using PetShippingNS.Api.Contracts;
using PetShippingNS.Api.Services;
using System;
using System.Collections.Generic;
using System.Linq;

namespace PetShippingNS.Api.Web
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
    <Hash>6c90a72eaa410dd42cd3f87410c2a9a4</Hash>
</Codenesium>*/