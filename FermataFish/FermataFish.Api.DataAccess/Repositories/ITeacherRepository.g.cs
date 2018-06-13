using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ITeacherRepository
        {
                Task<Teacher> Create(Teacher item);

                Task Update(Teacher item);

                Task Delete(int id);

                Task<Teacher> Get(int id);

                Task<List<Teacher>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");

                Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);
                Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);
        }
}

/*<Codenesium>
    <Hash>a5f88fee752e176eb31387a30948ac8c</Hash>
</Codenesium>*/