using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;

namespace FermataFishNS.Api.Services
{
        public interface IDALTeacherSkillMapper
        {
                TeacherSkill MapBOToEF(
                        BOTeacherSkill bo);

                BOTeacherSkill MapEFToBO(
                        TeacherSkill efTeacherSkill);

                List<BOTeacherSkill> MapEFToBO(
                        List<TeacherSkill> records);
        }
}

/*<Codenesium>
    <Hash>8cbc7ffe7865907814435f95687bfe63</Hash>
</Codenesium>*/