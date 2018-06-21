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
        [Route("api/teacherSkills")]
        [ApiVersion("1.0")]
        public class TeacherSkillController : AbstractTeacherSkillController
        {
                public TeacherSkillController(
                        ApiSettings settings,
                        ILogger<TeacherSkillController> logger,
                        ITransactionCoordinator transactionCoordinator,
                        ITeacherSkillService teacherSkillService
                        )
                        : base(settings,
                               logger,
                               transactionCoordinator,
                               teacherSkillService)
                {
                        this.BulkInsertLimit = 250;
                        this.MaxLimit = 1000;
                        this.DefaultLimit = 250;
                }
        }
}

/*<Codenesium>
    <Hash>e9c69ec3701aba064809ec2c1af3ab28</Hash>
</Codenesium>*/