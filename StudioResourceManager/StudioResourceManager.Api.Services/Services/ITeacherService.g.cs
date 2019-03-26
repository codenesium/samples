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

		Task<List<ApiTeacherServerResponseModel>> All(int limit = int.MaxValue, int offset = 0, string query = "");

		Task<List<ApiTeacherServerResponseModel>> ByUserId(int userId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiEventTeacherServerResponseModel>> EventTeachersByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiRateServerResponseModel>> RatesByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);

		Task<List<ApiTeacherTeacherSkillServerResponseModel>> TeacherTeacherSkillsByTeacherId(int teacherId, int limit = int.MaxValue, int offset = 0);
	}
}

/*<Codenesium>
    <Hash>a1e82438262bfac3c11b91508d278791</Hash>
</Codenesium>*/