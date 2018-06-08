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

                Task<List<TeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>4483134a722b7e4148530b1a5ffd39e2</Hash>
</Codenesium>*/