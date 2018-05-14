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
			TeacherXTeacherSkillModel model);

		Task<ActionResponse> Update(int id,
		                            TeacherXTeacherSkillModel model);

		Task<ActionResponse> Delete(int id);

		POCOTeacherXTeacherSkill Get(int id);

		List<POCOTeacherXTeacherSkill> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>3591705ea8d7a71e4e34bfb1da279f05</Hash>
</Codenesium>*/