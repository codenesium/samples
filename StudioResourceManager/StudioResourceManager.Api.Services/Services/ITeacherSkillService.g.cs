using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherSkillService
	{
		Task<CreateResponse<ApiTeacherSkillServerResponseModel>> Create(
			ApiTeacherSkillServerRequestModel model);

		Task<UpdateResponse<ApiTeacherSkillServerResponseModel>> Update(int id,
		                                                                 ApiTeacherSkillServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherSkillServerResponseModel> Get(int id);

		Task<List<ApiTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherSkillServerResponseModel>> ByTeacherId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>2fa8029ccf4e33e06e06c03149aed8b9</Hash>
</Codenesium>*/