using StudioResourceManagerMTNS.Api.Contracts;
using StudioResourceManagerMTNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerMTNS.Api.Services
{
	public partial interface IRateService
	{
		Task<CreateResponse<ApiRateServerResponseModel>> Create(
			ApiRateServerRequestModel model);

		Task<UpdateResponse<ApiRateServerResponseModel>> Update(int id,
		                                                         ApiRateServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiRateServerResponseModel> Get(int id);

		Task<List<ApiRateServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> ByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> ByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>3a713563e7acfe423a353c0ebd0e2fb5</Hash>
</Codenesium>*/