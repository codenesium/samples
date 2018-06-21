using Codenesium.Foundation.CommonMVC;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.Services;
using FluentValidation.Results;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Versioning;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;

namespace FermataFishNS.Api.Web
{
        [Route("api/studentXFamilies")]
        [ApiVersion("1.0")]
        public class StudentXFamilyController : AbstractStudentXFamilyController
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
    <Hash>adf6a1105a8f50a0b0222d79d103bc8f</Hash>
</Codenesium>*/