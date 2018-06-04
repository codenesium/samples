using System;
using System.Linq.Expressions;
using System.Collections.Generic;
using System.Threading.Tasks;
using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;

namespace FermataFishNS.Api.Services
{
	public interface ITeacherXTeacherSkillService
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
    <Hash>b3ac0df4fc4848ce6c0afd31d8e75be2</Hash>
</Codenesium>*/