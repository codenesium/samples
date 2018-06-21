using System;
using System.Collections.Generic;
using System.Linq.Expressions;
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
    <Hash>932969f59f1b7e2919abc07ac17c5068</Hash>
</Codenesium>*/