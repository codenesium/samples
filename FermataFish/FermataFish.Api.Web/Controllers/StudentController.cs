using System;
using Codenesium.Foundation.CommonMVC;
using FluentValidation.Results;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;

namespace FermataFishNS.Api.Web
{
        [Route("api/students")]
        [ApiVersion("1.0")]
        public class StudentController: AbstractStudentController
        {
                public StudentController(
                        ApiSettings settings,
                        ILogger<StudentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudentService studentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               studentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>651fb9b1e70bfd3ef58666fcb283da36</Hash>
</Codenesium>*/