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
        public class TeacherXTeacherSkillService: AbstractTeacherXTeacherSkillService, ITeacherXTeacherSkillService
        {
                public TeacherXTeacherSkillService(
                        ILogger<TeacherXTeacherSkillRepository> logger,
                        ITeacherXTeacherSkillRepository teacherXTeacherSkillRepository,
                        IApiTeacherXTeacherSkillRequestModelValidator teacherXTeacherSkillModelValidator,
                        IBOLTeacherXTeacherSkillMapper bolteacherXTeacherSkillMapper,
                        IDALTeacherXTeacherSkillMapper dalteacherXTeacherSkillMapper

                        )
                        : base(logger,
                               teacherXTeacherSkillRepository,
                               teacherXTeacherSkillModelValidator,
                               bolteacherXTeacherSkillMapper,
                               dalteacherXTeacherSkillMapper
                               )
                {
                }
        }
}

/*<Codenesium>
    <Hash>52a3dcd3a8a13b41a0cde4633f26dd46</Hash>
</Codenesium>*/