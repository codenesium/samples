using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherSkillRepository
	{
		Task<POCOTeacherSkill> Create(ApiTeacherSkillModel model);

		Task Update(int id,
		            ApiTeacherSkillModel model);

		Task Delete(int id);

		Task<POCOTeacherSkill> Get(int id);

		Task<List<POCOTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>5fc71a8910610f78d5ca24dc03e97263</Hash>
</Codenesium>*/