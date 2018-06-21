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
        [Route("api/lessonXTeachers")]
        [ApiVersion("1.0")]
        public class LessonXTeacherController : AbstractLessonXTeacherController
        {
                public LessonXTeacherController(
                        ApiSettings settings,
                        ILogger<LessonXTeacherController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonXTeacherService lessonXTeacherService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               lessonXTeacherService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>7b9896e5c57f6dfe80d8499ab0986e2c</Hash>
</Codenesium>*/