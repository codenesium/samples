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
        [Route("api/lessonStatus")]
        [ApiVersion("1.0")]
        public class LessonStatusController : AbstractLessonStatusController
        {
                public LessonStatusController(
                        ApiSettings settings,
                        ILogger<LessonStatusController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonStatusService lessonStatusService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               lessonStatusService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>8171895d7940ce1dfbc82fffb8b77472</Hash>
</Codenesium>*/