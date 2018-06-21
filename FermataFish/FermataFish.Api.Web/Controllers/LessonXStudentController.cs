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
        [Route("api/lessonXStudents")]
        [ApiVersion("1.0")]
        public class LessonXStudentController : AbstractLessonXStudentController
        {
                public LessonXStudentController(
                        ApiSettings settings,
                        ILogger<LessonXStudentController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonXStudentService lessonXStudentService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               lessonXStudentService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>6612870dbf86a627c08b297eb8d952ec</Hash>
</Codenesium>*/