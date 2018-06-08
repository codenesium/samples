using System;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

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
    <Hash>2c44277d24cb330f1ee76c5b7e4e0cd3</Hash>
</Codenesium>*/