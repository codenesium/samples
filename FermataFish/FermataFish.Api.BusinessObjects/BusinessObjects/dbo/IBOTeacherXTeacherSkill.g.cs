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
		Task<CreateResponse<int>> Create(
			TeacherXTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherXTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>42d8f3292a465b91c09358100219f438</Hash>
</Codenesium>*/