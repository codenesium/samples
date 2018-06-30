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
        [Route("api/departments")]
        [ApiVersion("1.0")]
        public class DepartmentController : AbstractDepartmentController
        {
                public DepartmentController(
                        ApiSettings settings,
                        ILogger<DepartmentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IDepartmentService departmentService,
                        IApiDepartmentModelMapper departmentModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               departmentService,
                               departmentModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>74441348fc4ddf0d68cd0ee6b00063bc</Hash>
</Codenesium>*/