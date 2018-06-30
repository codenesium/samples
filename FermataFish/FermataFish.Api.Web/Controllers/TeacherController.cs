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
                        ITeacherService teacherService,
                        IApiTeacherModelMapper teacherModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teacherService,
                               teacherModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>3534963de151a646c12aa6621caba9b1</Hash>
</Codenesium>*/