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
		Task<CreateResponse<ApiTeacherSkillResponseModel>> Create(
			ApiTeacherSkillRequestModel model);

		Task<ActionResponse> Update(int id,
		                            ApiTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherSkillResponseModel> Get(int id);

		Task<List<ApiTeacherSkillResponseModel>> All(int skip = 0, int take = int.MaxValue, string orderClause = "");
	}
}

/*<Codenesium>
    <Hash>6eacf213065cffd81e1c349988779253</Hash>
</Codenesium>*/