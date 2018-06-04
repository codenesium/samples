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
    <Hash>8d83bc80977aa425e7628dea80bca816</Hash>
</Codenesium>*/