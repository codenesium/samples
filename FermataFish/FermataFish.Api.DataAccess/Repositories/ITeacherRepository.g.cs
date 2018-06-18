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

                Task<List<Teacher>> All(int limit = int.MaxValue, int offset = 0);

                Task<List<Rate>> Rates(int teacherId, int limit = int.MaxValue, int offset = 0);
                Task<List<TeacherXTeacherSkill>> TeacherXTeacherSkills(int teacherId, int limit = int.MaxValue, int offset = 0);

                Task<Studio> GetStudio(int studioId);
        }
}

/*<Codenesium>
    <Hash>7516240f433f7f72161854206d633d63</Hash>
</Codenesium>*/