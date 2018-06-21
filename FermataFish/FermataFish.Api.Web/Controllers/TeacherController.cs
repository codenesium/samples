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
        [Route("api/teachers")]
        [ApiVersion("1.0")]
        public class TeacherController : AbstractTeacherController
        {
                public TeacherController(
                        ApiSettings settings,
                        ILogger<TeacherController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherService teacherService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teacherService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3e61dbd921d50ebfde606b1fba1a7859</Hash>
</Codenesium>*/