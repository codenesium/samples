using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacherSkill
	{
		Task<CreateResponse<POCOTeacherSkill>> Create(
			ApiTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherSkill Get(int id);

		List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>247e5c2566e686a9f4cae34d74959781</Hash>
</Codenesium>*/