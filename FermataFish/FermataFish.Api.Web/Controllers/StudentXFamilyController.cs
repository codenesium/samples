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
        [Route("api/studentXFamilies")]
        [ApiVersion("1.0")]
        public class StudentXFamilyController: AbstractStudentXFamilyController
        {
                public StudentXFamilyController(
                        ApiSettings settings,
                        ILogger<StudentXFamilyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudentXFamilyService studentXFamilyService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               studentXFamilyService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5aff11b8d483fd78966ffac5f9694b02</Hash>
</Codenesium>*/