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
			TeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherSkill Get(int id);

		List<POCOTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>9866a8cf2edb09f0bc607ced2d92401f</Hash>
</Codenesium>*/