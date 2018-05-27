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
		Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherXTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherXTeacherSkillResponseModel> Get(int id);

		Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>e18859fe79f8afc7f48191b04f6d151a</Hash>
</Codenesium>*/