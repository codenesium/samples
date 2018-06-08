using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
        public interface IDALTeacherXTeacherSkillMapper
        {
                TeacherXTeacherSkill MapBOToEF(
                        BOTeacherXTeacherSkill bo);

                BOTeacherXTeacherSkill MapEFToBO(
                        TeacherXTeacherSkill efTeacherXTeacherSkill);

                List<BOTeacherXTeacherSkill> MapEFToBO(
                        List<TeacherXTeacherSkill> records);
        }
}

/*<Codenesium>
    <Hash>0bd2fda6c7576df9fdd64468fd58c7f0</Hash>
</Codenesium>*/