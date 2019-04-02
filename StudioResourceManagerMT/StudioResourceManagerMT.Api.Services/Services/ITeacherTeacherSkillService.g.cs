using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface ITeacherTeacherSkillService
	{
		Task<CreateResponse<ApiTeacherTeacherSkillServerResponseModel>> Create(
			ApiTeacherTeacherSkillServerRequestModel model);

		Task<UpdateResponse<ApiTeacherTeacherSkillServerResponseModel>> Update(int id,
		                                                                        ApiTeacherTeacherSkillServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherTeacherSkillServerResponseModel> Get(int id);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");
	}
}

/*<Codenesium>
    <Hash>207ac5faef43a2337169292a3dbd4bc1</Hash>
</Codenesium>*/