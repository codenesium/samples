using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ITeacherXTeacherSkillRepository
        {
                Task<TeacherXTeacherSkill> Create(TeacherXTeacherSkill item);

                Task Update(TeacherXTeacherSkill item);

                Task Delete(int id);

                Task<TeacherXTeacherSkill> Get(int id);

                Task<List<TeacherXTeacherSkill>> All(int limit = int.MaxValue, int offset = 0);

                Task<Teacher> GetTeacher(int teacherId);
                Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
        }
}

/*<Codenesium>
    <Hash>db0063dd6d9771b1442c31429e119320</Hash>
</Codenesium>*/