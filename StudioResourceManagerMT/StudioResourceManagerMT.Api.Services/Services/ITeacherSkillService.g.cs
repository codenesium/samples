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

		Task<List<ApiTeacherSkillServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTeacherSkillId(int teacherSkillId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>78a022376ea923a3c4ff12ef0dc855fe</Hash>
</Codenesium>*/