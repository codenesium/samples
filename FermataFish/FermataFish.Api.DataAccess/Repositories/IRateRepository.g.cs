using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface IRateRepository
        {
                Task<Rate> Create(Rate item);

                Task Update(Rate item);

                Task Delete(int id);

                Task<Rate> Get(int id);

                Task<List<Rate>> All(int limit = int.MaxValue, int offset = 0);

                Task<Teacher> GetTeacher(int teacherId);

                Task<TeacherSkill> GetTeacherSkill(int teacherSkillId);
        }
}

/*<Codenesium>
    <Hash>2d729b2f181f3906d9778b38a3f05f4d</Hash>
</Codenesium>*/