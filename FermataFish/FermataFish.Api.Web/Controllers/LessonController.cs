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
        [Route("api/lessons")]
        [ApiVersion("1.0")]
        public class LessonController: AbstractLessonController
        {
                public LessonController(
                        ServiceSettings settings,
                        ILogger<LessonController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ILessonService lessonService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               lessonService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>11d92da9c877f43d787e2d32e2ea7360</Hash>
</Codenesium>*/