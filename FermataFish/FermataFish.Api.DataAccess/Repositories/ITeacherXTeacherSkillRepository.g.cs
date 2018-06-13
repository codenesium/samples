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

                Task<List<TeacherXTeacherSkill>> All(int limit = int.MaxValue, int offset =  0, string orderClause = "");
        }
}

/*<Codenesium>
    <Hash>2a5b8b8d4c50cea0005ff50debe395b2</Hash>
</Codenesium>*/