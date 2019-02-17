using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ITeacherSkillService
	{
		Task<CreateResponse<ApiTeacherSkillServerResponseModel>> Create(
			ApiTeacherSkillServerRequestModel model);

		Task<UpdateResponse<ApiTeacherSkillServerResponseModel>> Update(int id,
		                                                                 ApiTeacherSkillServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherSkillServerResponseModel> Get(int id);

		Task<List<ApiTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>82492a5f9442f4503dfba3e195bc02fb</Hash>
</Codenesium>*/