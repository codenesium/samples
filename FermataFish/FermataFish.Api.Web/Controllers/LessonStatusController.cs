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
        [Route("api/lessonStatus")]
        [ApiVersion("1.0")]
        public class LessonStatusController: AbstractLessonStatusController
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
    <Hash>77f8867e21165b72bba96eaf7a4bcc39</Hash>
</Codenesium>*/