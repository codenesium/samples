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
        [Route("api/teacherXTeacherSkills")]
        [ApiVersion("1.0")]
        public class TeacherXTeacherSkillController: AbstractTeacherXTeacherSkillController
        {
                public TeacherXTeacherSkillController(
                        ApiSettings settings,
                        ILogger<TeacherXTeacherSkillController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherXTeacherSkillService teacherXTeacherSkillService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teacherXTeacherSkillService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>5d2b5c6dc95bf65f004017bb788e8dcf</Hash>
</Codenesium>*/