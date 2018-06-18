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
        [Route("api/teachers")]
        [ApiVersion("1.0")]
        public class TeacherController: AbstractTeacherController
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
    <Hash>1e65a24e282fea9229447e601c0e68ce</Hash>
</Codenesium>*/