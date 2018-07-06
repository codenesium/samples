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
        [ApiController]
        [ApiVersion("1.0")]
        public class StudentXFamilyController : AbstractStudentXFamilyController
        {
                public StudentXFamilyController(
                        ApiSettings settings,
                        ILogger<StudentXFamilyController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        IStudentXFamilyService studentXFamilyService,
                        IApiStudentXFamilyModelMapper studentXFamilyModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               studentXFamilyService,
                               studentXFamilyModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>fae01340f94d2d8d2b57b86b1ee04465</Hash>
</Codenesium>*/