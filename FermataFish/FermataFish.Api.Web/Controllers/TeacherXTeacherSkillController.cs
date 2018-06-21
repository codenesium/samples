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
        [Route("api/teacherXTeacherSkills")]
        [ApiVersion("1.0")]
        public class TeacherXTeacherSkillController : AbstractTeacherXTeacherSkillController
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
    <Hash>7e68ace7c2ae9bbda3b34fca5c1659eb</Hash>
</Codenesium>*/