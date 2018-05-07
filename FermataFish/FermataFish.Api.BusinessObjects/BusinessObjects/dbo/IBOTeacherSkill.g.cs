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
		Task<CreateResponse<int>> Create(
			TeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherSkill Get(int id);

		List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>95250e1a4cb0912a6afc42080ccde058</Hash>
</Codenesium>*/