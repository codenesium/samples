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
        [Route("api/departments")]
        [ApiVersion("1.0")]
        public class DepartmentController: AbstractDepartmentController
        {
                public DepartmentController(
                        ServiceSettings settings,
                        ILogger<DepartmentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDepartmentService departmentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               departmentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>f0190233c4af5daea37268cbcdd14eaa</Hash>
</Codenesium>*/