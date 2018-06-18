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
        [Route("api/lessonXStudents")]
        [ApiVersion("1.0")]
        public class LessonXStudentController: AbstractLessonXStudentController
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
    <Hash>8677dd43a625772817d94e2f78269c14</Hash>
</Codenesium>*/