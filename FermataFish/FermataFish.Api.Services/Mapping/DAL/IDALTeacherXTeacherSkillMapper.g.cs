using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

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
    <Hash>24d55239bbda2af36845f9c678a8a458</Hash>
</Codenesium>*/