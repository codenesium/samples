using StudioResourceManagerNS.Api.Contracts;
using StudioResourceManagerNS.Api.DataAccess;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace StudioResourceManagerNS.Api.Services
{
	public partial interface ITeacherService
	{
		Task<CreateResponse<ApiTeacherServerResponseModel>> Create(
			ApiTeacherServerRequestModel model);

		Task<UpdateResponse<ApiTeacherServerResponseModel>> Update(int id,
		                                                            ApiTeacherServerRequestModel model);

		Task<ActionResponse> Delete(int id);

		Task<ApiTeacherServerResponseModel> Get(int id);

		Task<List<ApiTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> ByEventId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherServerResponseModel>> ByTeacherSkillId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>f3acdf5c1a9ce32d0b4a8e9c6bfcad4a</Hash>
</Codenesium>*/