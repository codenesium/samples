using FermataFishNS.Api.Contracts;
using FermataFishNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace FermataFishNS.Api.Services
{
	public partial interface ITeacherXTeacherSkillService
	{
		Task<CreateResponse<ApiTeacherXTeacherSkillResponseModel>> Create(
			ApiTeacherXTeacherSkillRequestModel model);

		Task<UpdateResponse<ApiTeacherXTeacherSkillResponseModel>> Update(int id,
		                                                                   ApiTeacherXTeacherSkillRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherXTeacherSkillResponseModel> Get(int id);

		Task<List<ApiTeacherXTeacherSkillResponseModel>> All(int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>92baee6db9a91b85eb2d287ac982c9e4</Hash>
</Codenesium>*/