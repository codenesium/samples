using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace FermataFishNS.Api.DataAccess
{
        public interface ITeacherSkillRepository
        {
                Task<TeacherSkill> Create(TeacherSkill item);

                Task Update(TeacherSkill item);

                Task Delete(int id);

                Task<TeacherSkill> Get(int id);

                Task<List<TeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>09bf2f41adcc0ac0ce57d239f57492a1</Hash>
</Codenesium>*/