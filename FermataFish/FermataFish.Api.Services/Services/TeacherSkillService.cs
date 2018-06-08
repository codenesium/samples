using Codenesium.DataConversionExtensions.AspNetCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Dynamic.Core;
using System.Linq.Expressions;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public class TeacherSkillService: AbstractTeacherSkillService, ITeacherSkillService
        {
                public TeacherSkillService(
                        ILogger<TeacherSkillRepository> logger,
                        ITeacherSkillRepository teacherSkillRepository,
                        IApiTeacherSkillRequestModelValidator teacherSkillModelValidator,
                        IBOLTeacherSkillMapper bolteacherSkillMapper,
                        IDALTeacherSkillMapper dalteacherSkillMapper)
                        : base(logger,
                               teacherSkillRepository,
                               teacherSkillModelValidator,
                               bolteacherSkillMapper,
                               dalteacherSkillMapper)
                {
                }
        }
}

/*<Codenesium>
    <Hash>239b8f8ff0520064f27e272c13ec74e1</Hash>
</Codenesium>*/