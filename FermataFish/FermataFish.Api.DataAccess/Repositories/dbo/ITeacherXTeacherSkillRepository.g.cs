using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;

namespace FermataFishNS.Api.DataAccess
{
	public interface ITeacherXTeacherSkillRepository
	{
		Task<POCOTeacherXTeacherSkill> Create(ApiTeacherXTeacherSkillModel model);

		Task Update(int id,
		            ApiTeacherXTeacherSkillModel model);

		Task Delete(int id);

		Task<POCOTeacherXTeacherSkill> Get(int id);

		Task<List<POCOTeacherXTeacherSkill>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>1c42b7f590d0aa3b403074204cbc4eb4</Hash>
</Codenesium>*/