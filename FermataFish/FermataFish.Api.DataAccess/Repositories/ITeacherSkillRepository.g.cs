using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ITeacherSkillRepository
        {
                Task<TeacherSkill> Create(TeacherSkill item);

                Task Update(TeacherSkill item);

                Task Delete(int id);

                Task<TeacherSkill> Get(int id);

                Task<List<TeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Rate>> Rates(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

                Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int studioId);
        }
}

/*<Codenesium>
    <Hash>b0aaec6b05057724fb26e3cb6b1155eb</Hash>
</Codenesium>*/