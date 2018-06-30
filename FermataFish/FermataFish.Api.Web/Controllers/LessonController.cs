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
        [Route("api/lessons")]
        [ApiVersion("1.0")]
        public class LessonController : AbstractLessonController
        {
                public LessonController(
                        ApiSettings settings,
                        ILogger<LessonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonService lessonService,
                        IApiLessonModelMapper lessonModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               lessonService,
                               lessonModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>77fbfe4cbd083ed50599cb4e85c0a944</Hash>
</Codenesium>*/