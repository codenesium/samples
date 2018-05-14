using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.BusinessObjects
{
	public interface IBOTeacherXTeacherSkill
	{
		Task<CreateResponse<POCOTeacherXTeacherSkill>> Create(
			ApiTeacherXTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherXTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>0e5110fd7468730651a323ff00e93d34</Hash>
</Codenesium>*/