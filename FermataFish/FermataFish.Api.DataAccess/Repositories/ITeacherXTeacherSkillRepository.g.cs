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
    <Hash>0e14734b5e96e6e3104051faec1d1b5b</Hash>
</Codenesium>*/