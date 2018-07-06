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
        [ApiController]
        [ApiVersion("1.0")]
        public class TeacherXTeacherSkillController : AbstractTeacherXTeacherSkillController
        {
                public TeacherXTeacherSkillController(
                        ApiSettings settings,
                        ILogger<TeacherXTeacherSkillController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherXTeacherSkillService teacherXTeacherSkillService,
                        IApiTeacherXTeacherSkillModelMapper teacherXTeacherSkillModelMapper
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teacherXTeacherSkillService,
                               teacherXTeacherSkillModelMapper)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>0ae685d6e0677d645af51ee614d50299</Hash>
</Codenesium>*/